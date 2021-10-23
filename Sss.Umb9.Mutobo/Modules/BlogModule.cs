using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class BlogModule : MutoboContentModule, IModule
    {
        public IPublishedContent ParentPage => this.HasValue(DocumentTypes.BlogModule.Fields.ParentPage) ?
            this.Value<IPublishedContent>(DocumentTypes.BlogModule.Fields.ParentPage) : null;

        public IEnumerable<ArticlePage> BlogEntries {get; set;}

        public BlogModule(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        { 
            return await helper.PartialAsync("~/Views/Modules/BlogList.cshtml", this, helper.ViewData);
        }
    }
}
