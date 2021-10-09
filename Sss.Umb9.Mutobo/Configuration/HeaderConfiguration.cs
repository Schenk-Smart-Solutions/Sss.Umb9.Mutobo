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
    public class HeaderConfiguration : PublishedElementModel, IHeaderConfiguration
    {
        public IEnumerable<NavItem> NavigationItems { get; set; }

        public Image Logo { get; set; }

        public Link LogoUrl => this.Value<Link>(DocumentTypes.Configuration.Link);

        public IEnumerable<Sss.Umb9.Mutobo.PoCo.Language> Languages { get; set; }

        public Image StageImage { get; set; }

        public HeaderConfiguration(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, null)
        {



        }
    }
}
