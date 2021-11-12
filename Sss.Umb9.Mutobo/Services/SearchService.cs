using Examine;
using Examine.Search;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Common.Exceptions;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Extensions;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class SearchService : BaseService, ISearchService
    {
        protected readonly IPageLayoutService PageLayoutService;
        private readonly IExamineManager _examineManager;
        private readonly IMediaService _mediaService;

        public SearchService(
            ILogger<SearchService> logger, 
            IUmbracoContextAccessor contextAccessor,
            IPageLayoutService pageLayoutService,
            IExamineManager examineManager,
            IMediaService mediaService) 
            : base(logger, contextAccessor)
        {
            PageLayoutService = pageLayoutService;
            _examineManager = examineManager;
            _mediaService = mediaService;

        }

        public virtual SearchResultModel PerformSearch(string term)
        {

            SearchResultModel result = null;
            try
            {
                // create the result object and assign the search term 
                result = new SearchResultModel(CurrentPage)
                {
                    HeaderConfiguration = PageLayoutService.GetHeaderConfiguration(CurrentPage),
                    FooterConfiguration = PageLayoutService.GetFooterConfiguration(CurrentPage),
                    Term = term ?? string.Empty
                };
            }
            catch (AppSettingsException e)
            {
                //TODO: Logging
                //Logger.Error(this.GetType(), e, $"{AppConstants.LoggingPrefix} {e.Message}");
                throw e;
            }


            if (_examineManager.TryGetIndex("ExternalIndex", out var index))
            {
                var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString().ToLower();
                var searchTerm = HtmlHelperExtensions.SearchFriendlyString(term);
                var diffFields = new string[] { 
                    "nodeName", 
                    "__NodeTypeAlias", 
                    "fileTextContent", 
                    "abstract_" + currentCulture, 
                    "abstract", 
                    "mainContent", 
                    "pageTitle", 
                    "modules"
                };

                if (!string.IsNullOrEmpty(term))
                {
                    var query = index.Searcher.CreateQuery(null, BooleanOperation.And)
                                    .GroupedOr(diffFields, searchTerm);
                    var results = query.Execute();

                    result.Results = results
                        .Select(r => Context.Content.GetById(false, int.Parse(r.Id)))
                        .Select(node => new PoCo.SearchResult
                        {
                            Url = node.Url(),
                            Abstract = node.HasProperty(DocumentTypes.ArticlePage.Fields.Abstract) ? node.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract) : string.Empty,
                            Title = node.HasProperty(DocumentTypes.BasePage.Fields.PageTitle) &&
                                                 node.HasValue(DocumentTypes.BasePage.Fields.PageTitle) &&
                                                 !string.IsNullOrEmpty(node.Value<string>(DocumentTypes.BasePage.Fields.PageTitle).Trim()) ?
                                             node.Value<string>(DocumentTypes.BasePage.Fields.PageTitle) :
                                             node.Name,
                            UrlTitle = "Mehr erfahren"

                        });
                }
                else {
                    result.Results = new List<Sss.Umb9.Mutobo.PoCo.SearchResult>();
                }

            }
            else
            {
                throw new SearchException("ExternalIndex is not present");
            }



            return result;

        }





        //public IEnumerable<IPublishedContent> GetLinkedPages(IPublishedContent media)
        //{
        //    var result = new List<IPublishedContent>();

        //    var homepage = Helper
        //        .ContentAtRoot()
        //        .FirstOrDefault(p => p.IsComposedOf(DocumentTypes.HomePage.Alias));

        //    foreach (var page in homepage.DescendantsOrSelf())
        //    {

        //        foreach (var prop in page.Properties)
        //        {
        //            if (prop.GetValue() is IPublishedContent content)
        //            {
        //                if (content.Id == media.Id)
        //                    result.Add(page);
        //            }
        //            else if (prop.GetValue() is IPublishedElement element)
        //            {
        //                if (IsLinkedElementType(element, media.Id))
        //                {
        //                    result.Add(page);
        //                }
        //            }
        //            else if (prop.GetValue() is IEnumerable<IPublishedElement> elementList)
        //            {
        //                foreach (var el in elementList)
        //                {
        //                    if (IsLinkedElementType(el, media.Id))
        //                    {
        //                        result.Add(page);
        //                    }
        //                }
        //            }
        //        }

        //    }

        //    return result;
        //}


        private bool IsLinkedElementType(IPublishedElement element, int mediaId)
        {
            var result = false;

            foreach (var prop in element.Properties)
            {
                // TODO fix this
                if (prop.GetValue() is IPublishedContent content)
                {
                    result = content.Id == mediaId;
                }
                else if (prop.GetValue() is IPublishedElement childElement)
                {
                    result |= IsLinkedElementType(childElement, mediaId);
                }
                else if (prop.GetValue() is IEnumerable<IPublishedElement> elementList)
                {
                    foreach (var el in elementList)
                    {
                        result |= IsLinkedElementType(el, mediaId);
                    }

                }
            }

            return result;
        }



        public IEnumerable<ISearchResult> GetPageOfSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IPublishedContent> ISearchService.GetPageOfContentSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
