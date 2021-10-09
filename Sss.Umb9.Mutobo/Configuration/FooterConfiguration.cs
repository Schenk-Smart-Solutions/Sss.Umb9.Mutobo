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

namespace Sss.Umb9.Mutobo.Configuration
{
    public class FooterConfiguration : PublishedElementModel, IFooterConfiguration
    {
        public IEnumerable<FooterNavBlock> FooterNavBlocks { get; set; }

        public IEnumerable<Link> FooterLinks =>
            this.Value<IEnumerable<Link>>(DocumentTypes.FooterConfiguration.Fields.Links);

        public IEnumerable<FooterContactArea> FooterContactBlock { get; set; }

        public IEnumerable<PoCo.Language> Languages { get; set; }


        public IEnumerable<PictureLink> PictureLinks { get; set; }

        public Image HomePageLogo { get; set; }

        public string Copyright => $"&copy; {DateTime.Today.Year} {this.Value<string>(DocumentTypes.FooterConfiguration.Fields.CopyRight)}";

        public IEnumerable<Link> BlockLinks => this.Value<IEnumerable<Link>>(DocumentTypes.FooterConfiguration.Fields.BlockLinks);


        public string Theme { get; set; }

        public FooterConfiguration(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }
    }
}
