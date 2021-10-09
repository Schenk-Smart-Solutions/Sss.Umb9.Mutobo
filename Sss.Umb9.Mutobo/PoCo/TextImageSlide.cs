using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PoCo
{
    public class TextImageSlide : MutoboContentModule, ISliderItem
    {
        public Image Image { get; set; }

        public string Text => this.HasValue(DocumentTypes.TextImageSlide.Fields.Text)
            ? this.Value<string>(DocumentTypes.TextImageSlide.Fields.Text)
            : null;

        public Link Link => this.HasValue(DocumentTypes.TextImageSlide.Fields.Link)
            ? this.Value<Link>(DocumentTypes.TextImageSlide.Fields.Link)
            : null;
        public string Title => this.HasValue(DocumentTypes.TextImageSlide.Fields.Title)
            ? this.Value<string>(DocumentTypes.TextImageSlide.Fields.Title)
            : null;



        public TextImageSlide(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }
    }
}
