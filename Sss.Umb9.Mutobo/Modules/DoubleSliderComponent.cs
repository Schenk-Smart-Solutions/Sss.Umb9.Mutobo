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
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class DoubleSliderComponent : MutoboContentModule, IModule
    {
        public IEnumerable<TextImageSlide> Slides { get; set; }


        public int? Height => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Height)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Height)
            : null;

        public int? Interval => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Interval)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Interval) : null;



        public int? Width => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Width)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Width)
            : null;



        public DoubleSliderComponent(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }


        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";
            EGalleryType galleryType = EGalleryType.FullWidth;

            if (this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.DisplayType))
            {
                galleryType = (EGalleryType)System.Enum.Parse(typeof(EGalleryType),
                    this.Value<string>(DocumentTypes.DoubleSliderComponent.Fields.DisplayType));

                if (galleryType == EGalleryType.Boxed)
                    result = "picture-";
            }

            return result;
        }

        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
           
            return await helper.PartialAsync("~/Views/Modules/DoubleSlider.cshtml", this, helper.ViewData);
           
        }
    }
}
