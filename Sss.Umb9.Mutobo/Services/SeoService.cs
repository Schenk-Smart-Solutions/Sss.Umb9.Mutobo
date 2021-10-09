using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Configuration;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Extensions;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class SeoService : BaseService, ISeoService
    {
        public SeoService(ILogger<SeoService> logger, IUmbracoContextAccessor contextAccessor) : base(logger, contextAccessor)
        {
        }

        public SeoConfiguration GetSeoConfiguration()
        {
            var keywords = string.Empty;

            keywords = GetKeyWords();



            return new SeoConfiguration
            {
                MetaTitle = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaTitle, CurrentPage),
                MetaDescription = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaDescription, CurrentPage),
                MetaKeywords = keywords,
                ThumbNailWidth = 300,
                ThumbNailHeight = 300,
       
            };

        }



        private string GetAbstract()
        {
            var result = string.Empty;
            return result;
        }

        private string GetKeyWords()
        {
            string result = String.Empty;




            var allKeywords = CurrentPage
                .AncestorsOrSelf()
                .ToList()
                .FirstOrDefault(c => c.ContentType.Alias == DocumentTypes.HomePage.Alias)
                ?.DescendantsOrSelf()
                .ToList()
                .Where(c =>
                    c.HasProperty(DocumentTypes.BasePage.Fields.MetaKeywords) &&
                    c.HasValue(DocumentTypes.BasePage.Fields.MetaKeywords));






            if (allKeywords != null)
                foreach (var keyWords in allKeywords)
                {
                    var value = keyWords.Value<string>(DocumentTypes.BasePage.Fields.MetaKeywords);
                    if (value.EndsWith(","))
                        result += value.TrimEnd() + " ";
                    else
                    {
                        result += $"{value}, ";
                    }
                }

            return result?.TrimEnd().TrimEnd(',');
        }


        private string GetMetaDataValue(string fieldName, IPublishedContent content)
        {
            var nodes = content.AncestorsOrSelf();

            foreach (var node in nodes)
            {
                var result = node.Value<string>(fieldName);




                if (fieldName == DocumentTypes.BasePage.Fields.MetaDescription && string.IsNullOrEmpty(result))
                {
                    result = node.HasProperty(DocumentTypes.ArticlePage.Fields.Abstract) &&
                             node.HasValue(DocumentTypes.ArticlePage.Fields.Abstract)
                        ? node.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract)
                        : string.Empty;
                }

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return string.Empty;
        }
    }
}
