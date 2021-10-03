using Microsoft.AspNetCore.Html;
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

        public IEnumerable<ArticlePage> BlogEntries => this.HasValue(DocumentTypes.BlogModule.Fields.ParentPage)
    ? this.Value<IPublishedContent>(DocumentTypes.BlogModule.Fields.ParentPage).Children.OrderByDescending(c => c.CreateDate)
        .Select(c => new ArticlePage(c))
    : null;

        public BlogModule(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public override IHtmlContent RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.PartialAsync("~/Views/Modules/BlogList.cshtml", this, helper.ViewData));
            return new HtmlString(bld.ToString());
        }
    }
}
