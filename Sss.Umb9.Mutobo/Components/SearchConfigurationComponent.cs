using Examine;
using Examine.Lucene.Search;
using UmbracoExamine.PDF;
using Sss.Umb9.Mutobo.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;
using Examine.Lucene.Providers;

namespace Sss.Umb9.Mutobo.Components
{
    public class SearchConfigurationComponent : IComponent
    {
        private readonly IExamineManager _examineManager;
        private readonly IUmbracoContextFactory _contextFactory;


        public SearchConfigurationComponent(IExamineManager examineManager, IUmbracoContextFactory contextFactory)
        {

            // inject ExamineManager
            _examineManager = examineManager;
            //
            _contextFactory = contextFactory;
        }



        public void Initialize()
        {
            IIndex externalIndex = null;
            IIndex pdfIndex = null;

            if (_examineManager.TryGetIndex("ExternalIndex", out externalIndex))
            {

               
                // FieldDefinitionCollection contains all indexed fields 
                externalIndex.FieldDefinitions.Append(new FieldDefinition("contents", FieldDefinitionTypes.FullText));
                //((BaseIndexProvider)externalIndex).TransformingIndexValues += OnTransformingIndexValues;

                ////register multisearcher
                //var multisearch = new MultiIndexSearcher("MultiSearcher", new IIndex[] { externalIndex, pdfIndex });
                //_examineManager.AddSearcher(multiSearcher);

            }
            else
            {
                throw new Exception("Index not found");
            }
        }

        private void OnTransformingIndexValues(object sender, IndexingItemEventArgs e)
        {
            if (int.TryParse(e.ValueSet.Id, out var nodeId))
                switch (e.ValueSet.ItemType)
                {

                    case "contentPage":
                        using (var umbracoContext = _contextFactory.EnsureUmbracoContext())
                        {
                            IPublishedContent contentNode = umbracoContext.UmbracoContext.Content.GetById(nodeId);
                           // IPublishedElement element = umbracoContext.UmbracoContext.Content.GetById(nodeId);

                            if (contentNode != null)
                            {
                                var contentRichtext = string.Empty;
                                if (contentNode.Value<IEnumerable<IPublishedElement>>(DocumentTypes.ContentPage.Fields.Modules) != null)
                                {
                                    foreach (var item in contentNode.Value<IEnumerable<IPublishedElement>>(DocumentTypes.ContentPage.Fields.Modules))
                                    {

                                        if (item.HasProperty("richText"))
                                        {
                                            var ncRichtext = item.GetProperty("richText").GetValue();
                                            contentRichtext += " " + ncRichtext;
                                        }

                                    }

                                    e.ValueSet.Set("modules", contentRichtext);
                                }

                            }

                        }
                        break;
                }


        }

        public void Terminate()
        {
        }
    }
}

