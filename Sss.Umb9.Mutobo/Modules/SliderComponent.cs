using Microsoft.AspNetCore.Html;
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
    public class SliderComponent : MutoboContentModule, ISliderComponent, IModule
    {

        public IEnumerable<ISliderItem> Slides { get; set; }

        public int? Height => this.HasValue(DocumentTypes.SliderComponent.Fields.Height) && this.Value<int?>(DocumentTypes.SliderComponent.Fields.Height) > 0
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Height)
            : null;
        public int? Interval => this.HasValue(DocumentTypes.SliderComponent.Fields.Interval)
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Interval)
        : null;



        public int? Width => this.HasValue(DocumentTypes.SliderComponent.Fields.Width) && this.Value<int?>(DocumentTypes.SliderComponent.Fields.Width) > 0
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Width)
            : null;

        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";
            EGalleryType galleryType = EGalleryType.FullWidth;

            if (this.HasValue(DocumentTypes.SliderComponent.Fields.DisplayType))
            {
                galleryType = (EGalleryType)System.Enum.Parse(typeof(EGalleryType),
                    this.Value<string>(DocumentTypes.SliderComponent.Fields.DisplayType));

                if (galleryType == EGalleryType.Boxed)
                    result = "picture-";
            }

            return result;
        }

        public SliderComponent(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper)
        {
            return await helper.PartialAsync("~/Views/Modules/Slider.cshtml", this, helper.ViewData);
        }

    }
}
