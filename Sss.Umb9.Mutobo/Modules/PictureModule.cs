using Microsoft.AspNetCore.Html;
using Sss.Umb9.Mutobo.Constants;
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
    public class PictureModule : MutoboContentModule, IModule
    {
        public Image Image { get; set; }

        public int? Height => this.HasValue(DocumentTypes.PictureModule.Fields.Height)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Height)
            : null;


        public int? Width => this.HasValue(DocumentTypes.PictureModule.Fields.Width)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Width)
            : null;


        public PictureModule(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        

        public  async Task<IHtmlContent> RenderModule(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper)
        {
            return await helper.PartialAsync("~/Views/Modules/PictureModule.cshtml", this, helper.ViewData);
        }
    }
}
