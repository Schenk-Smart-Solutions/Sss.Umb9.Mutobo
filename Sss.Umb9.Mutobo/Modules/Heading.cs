using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Enum;
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
    public class Heading : MutoboContentModule, IModule
    {
        public string Text => this.HasValue(DocumentTypes.Heading.Fields.Text)
    ? this.Value<string>(DocumentTypes.Heading.Fields.Text)
    : string.Empty;

        public EHeadingRenderType RenderAs => this.HasValue(DocumentTypes.Heading.Fields.RenderAs)
            ? (EHeadingRenderType)System.Enum.Parse(typeof(EHeadingRenderType), this.Value<string>(DocumentTypes.Heading.Fields.RenderAs))
            : EHeadingRenderType.Heading1;

        public string NavigationAnchor => this.HasValue(DocumentTypes.Heading.Fields.NavigationAnchor)
            ? this.Value<string>(DocumentTypes.Heading.Fields.NavigationAnchor)
            : null;


        public Heading(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            var bld = new StringBuilder();

            var anchor = $"id=\"{NavigationAnchor}\"" ?? string.Empty;

            switch (RenderAs)
            {
                case EHeadingRenderType.Heading1:
                    bld.Append($"<h1 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h1>");
                    break;
                case EHeadingRenderType.Heading2:
                    bld.Append($"<h2 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h2>");
                    break;
                case EHeadingRenderType.Heading3:
                    bld.Append($"<h3 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h3>");
                    break;
                case EHeadingRenderType.Heading4:
                    bld.Append($"<h4 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h4>");
                    break;
                case EHeadingRenderType.Heading5:
                    bld.Append($"<h5 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h5>");
                    break;
                case EHeadingRenderType.Heading6:
                    bld.Append($"<h6 style=\"width:100%\" {anchor}>{Text.ToUpper()}</h6>");
                    break;
            }

            

            return await Task.FromResult<IHtmlContent>(new HtmlString(bld.ToString()));
        }
    }
}
