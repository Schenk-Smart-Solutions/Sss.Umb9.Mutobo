using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Enum;
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
    public class Teaser : MutoboContentModule, IModule
    {
        public Link Link => this.HasValue(DocumentTypes.Teaser.Fields.Link)
    ? this.Value<Link>(DocumentTypes.Teaser.Fields.Link)
    : null;

        public IEnumerable<Image> Images { get; set; }

        public bool UseArticleData => this.HasValue(DocumentTypes.Teaser.Fields.UseArticleData) && this.Value<bool>(DocumentTypes.Teaser.Fields.UseArticleData);

        public string TeaserTitle { get; set; }

        public string TeaserText { get; set; }

        public EHighlightRendering RenderAs => this.HasValue(DocumentTypes.Teaser.Fields.RenderAs)
            ? (EHighlightRendering)System.Enum.Parse(typeof(EHighlightRendering),
                this.Value<string>(DocumentTypes.Teaser.Fields.RenderAs))
            : EHighlightRendering.None;


        public Teaser(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public  async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            var bld = new StringBuilder();

            switch (RenderAs)
            {
                default:
                case EHighlightRendering.Teaser:
                    return await helper.PartialAsync("~/Views/Modules/NestedTeaser.cshtml", this);
    

                case EHighlightRendering.Gallery:
                    return await helper.PartialAsync("~/Views/Modules/GalleryTeaser.cshtml", this);
                 
            }

  
        }
    }
}
