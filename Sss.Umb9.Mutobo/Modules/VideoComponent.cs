using Microsoft.AspNetCore.Html;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class VideoComponent : MutoboContentModule, ISliderItem, IVideoComponent, IModule
    {
        public VideoComponent(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public Video Video => this.HasValue(DocumentTypes.VideoComponent.Fields.VideoFile)
            ? new Video()
            {
                Source = this.Value<IPublishedContent>(DocumentTypes.VideoComponent.Fields.VideoFile).MediaUrl()
            }
            : null;

        public String Embedded => this.HasValue(DocumentTypes.VideoComponent.Fields.Embedded)
            ? this.Value<string>(DocumentTypes.VideoComponent.Fields.Embedded)
            : null;

        public String Text => this.HasValue(DocumentTypes.VideoComponent.Fields.Text)
            ? this.Value<string>(DocumentTypes.VideoComponent.Fields.Text)
            : null;


        public int? Width => this.HasValue(DocumentTypes.VideoComponent.Fields.Width)
            ? this.Value<int?>(DocumentTypes.VideoComponent.Fields.Width)
            : null;



        public int? Height => this.HasValue(DocumentTypes.VideoComponent.Fields.Height)
            ? this.Value<int?>(DocumentTypes.VideoComponent.Fields.Height)
            : null;



        public IHtmlContent RenderIFrame(int? width = null, int? height = null)
        {
            var newWidth = width ?? Width;
            var newHeight = height ?? Height;
            var result = Embedded;

            if (newWidth.HasValue)
                result = Regex.Replace(result.ToLower(), "width=\"([0-9]{1,4})\"", $"width=\"{newWidth}\"");
            if (newHeight.HasValue)
                result = Regex.Replace(result.ToLower(), "height=\"([0-9]{1,4})\"", $"height=\"{newHeight}\"");

            return new HtmlString(result);
        }

        public async Task<IHtmlContent> RenderModule(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper)
        {
            
            return await helper.PartialAsync("~/Views/Modules/VideoComponent.cshtml", this, helper.ViewData);
            
        }
    }
}
