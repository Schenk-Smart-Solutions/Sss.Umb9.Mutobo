using Sss.Umb9.Mutobo.Constants;
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
    public class PictureLink : PublishedElementModel
    {



        public Image Image { get; set; }
        public Link Link => this.HasValue(DocumentTypes.PictureLink.Fields.Link)
            ? this.Value<Link>(DocumentTypes.PictureLink.Fields.Link)
        : null;
        public Link LogoLink => this.HasValue(DocumentTypes.PictureLink.Fields.LogoLink)
            ? this.Value<Link>(DocumentTypes.PictureLink.Fields.LogoLink)
            : null;
        public string Text => this.HasValue(DocumentTypes.PictureLink.Fields.Text) ? this.Value<string>(DocumentTypes.PictureLink.Fields.Text)
        : string.Empty;


        public int? MaxHeight => this.Value<int?>(DocumentTypes.PictureLink.Fields.MaxHeight);
        public int? PaddingTop => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingTop);
        public int? PaddingRight => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingRight);
        public int? PaddingBottom => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingBottom);
        public int? PaddingLeft => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingLeft);

        public PictureLink(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {


        }
    }
}
