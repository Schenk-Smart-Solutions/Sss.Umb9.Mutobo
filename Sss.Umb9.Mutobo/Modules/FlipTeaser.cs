using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class FlipTeaser : MutoboContentModule, IModule, IWrappable
    {
        

        public Image Image { get; set; }
        public string Title => this.HasValue(DocumentTypes.FlipTeaser.Fields.Title) ?
            this.Value<string>(DocumentTypes.FlipTeaser.Fields.Title) : string.Empty;

        public string Text => this.HasValue(DocumentTypes.FlipTeaser.Fields.Text) ?
         this.Value<string>(DocumentTypes.FlipTeaser.Fields.Text) : string.Empty;

        public Link Link => this.HasValue(DocumentTypes.FlipTeaser.Fields.Link) ?
         this.Value<Link>(DocumentTypes.FlipTeaser.Fields.Link) : null;

        public string Alias => this.ContentType.Alias;

        public FlipTeaser(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }


        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            var bld = new StringBuilder();
            return await helper.PartialAsync("~/Views/Modules/FlipTeaser.cshtml", this);
        }
    }

}
