using Sss.Umb9.Mutobo.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PoCo
{
    public class FooterContactArea : PublishedElementModel
    {
        public string Headline { get; set; }
        public string AddressBlock { get; set; }

        public FooterContactArea(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            Headline = content.HasValue(DocumentTypes.FooterContact.Headline) ? content.Value<string>(DocumentTypes.FooterContact.Headline) : string.Empty;
            AddressBlock = content.HasValue(DocumentTypes.FooterContact.AddressBlock) ? content.Value<string>(DocumentTypes.FooterContact.AddressBlock) : string.Empty;
        }
    }
}
