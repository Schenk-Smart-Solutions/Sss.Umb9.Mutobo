using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
    public class Accordeon : MutoboContentModule, IModule
    {

        public string Summary => this.HasValue(DocumentTypes.Accordeon.Fields.Summary)
    ? this.Value<string>(DocumentTypes.Accordeon.Fields.Summary)
    : null;
        public string Details => this.HasValue(DocumentTypes.Accordeon.Fields.Details)
            ? this.Value<string>(DocumentTypes.Accordeon.Fields.Details)
            : null;

        public Accordeon(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            return await helper.PartialAsync("~/Views/Modules/Accordeon.cshtml", this, helper.ViewData);
        }
    }
}
