using Microsoft.AspNetCore.Html;
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
    public class Flyer : MutoboContentModule, IModule
    {
        public string Title => this.Value<string>(DocumentTypes.Flyer.Fields.FlyerTitle);

        // Attributes for Frontend
        public string Color => this.Value<string>(DocumentTypes.Flyer.Fields.Color);

        public EDirection Direction => this.HasValue(DocumentTypes.Flyer.Fields.Direction) ?
            (EDirection)System.Enum.Parse(typeof(EDirection), this.Value<string>(DocumentTypes.Flyer.Fields.Direction)) :
            (EDirection)System.Enum.Parse(typeof(EDirection), "Undefined");

        public int Timer => this.Value<int>(DocumentTypes.Flyer.Fields.Timer);

        public EPosition Position =>
            (EPosition)System.Enum.Parse(typeof(EPosition), this.Value<string>(DocumentTypes.Flyer.Fields.Position));

        public int Height => this.Value<int>(DocumentTypes.Flyer.Fields.Height);
        public int Width => this.Value<int>(DocumentTypes.Flyer.Fields.Width);
        public int Rotation => this.Value<int>(DocumentTypes.Flyer.Fields.Rotation);
        public int MarginTop => this.Value<int>(DocumentTypes.Flyer.Fields.MarginTop);
        public int MarginSide => this.Value<int>(DocumentTypes.Flyer.Fields.MarginSide);
        public int? TextHeight => this.Value<int?>(DocumentTypes.Flyer.Fields.TextHeight);
        public int? TextWidth => this.Value<int?>(DocumentTypes.Flyer.Fields.TextWidth);



        public Image Image { get; set; }
        public string TeaserText { get; set; }
        public Link Link { get; set; }


        public Flyer(IPublishedElement content, IPublishedValueFallback publishedValueFallback) 
            : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper)
        {
            var bld = new StringBuilder();

            if (Timer > 0)
            {
                switch (Direction)
                {
                    case EDirection.Right:
                        bld.Append(await helper.PartialAsync("~/Views/Partials/Flyer_right.cshtml",
                            this, helper.ViewData));
                        break;

                    default:
                    case EDirection.Left:
                        bld.Append(await helper.PartialAsync("~/Views/Partials/Flyer_left.cshtml", this, helper.ViewData));
                        break;
                }
            }
            else
            {
                switch (Direction)
                {
                    case EDirection.Right:
                        bld.Append(await helper.PartialAsync("~/Views/Partials/IntersectionFlyer_right.cshtml", this, helper.ViewData));
                        break;

                    default:
                    case EDirection.Left:
                        bld.Append(await helper .PartialAsync("~/Views/Partials/IntersectionFlyer_left.cshtml", this, helper.ViewData));
                        break;
                }

            }

            return new HtmlString(bld.ToString());
        }

    }
}
