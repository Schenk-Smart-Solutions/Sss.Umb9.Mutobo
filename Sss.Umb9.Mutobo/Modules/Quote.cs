using Microsoft.AspNetCore.Html;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class Quote : MutoboContentModule, IModule
    {
        public string QuoteText => this.HasValue(DocumentTypes.Quote.Fields.QuoteText)
    ? this.Value<string>(DocumentTypes.Quote.Fields.QuoteText)
    : string.Empty;

        public string SpellerName => this.HasValue(DocumentTypes.Quote.Fields.SpellerName)
            ? this.Value<string>(DocumentTypes.Quote.Fields.SpellerName)
            : string.Empty;

        public string SpellerFunction => this.HasValue(DocumentTypes.Quote.Fields.SpellerFunction)
            ? this.Value<string>(DocumentTypes.Quote.Fields.SpellerFunction)
            : string.Empty;


        public Quote(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }


        public  async Task<IHtmlContent> RenderModule(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper)
        {
            return await helper.PartialAsync("~/Views/Modules/Quote.cshtml", this, helper.ViewData);
        }
    }
}
