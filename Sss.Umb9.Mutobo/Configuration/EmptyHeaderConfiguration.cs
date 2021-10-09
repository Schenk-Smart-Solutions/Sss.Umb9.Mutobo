using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace Sss.Umb9.Mutobo.Configuration
{
    public class EmptyHeaderConfiguration : IHeaderConfiguration
    {
        public IEnumerable<NavItem> NavigationItems { get; set; }
        public Image Logo { get; set; }
        public Link LogoUrl { get; set; }
        public IEnumerable<PoCo.Language> Languages { get; set; }
        public Image StageImage { get; set; }
    }
}
