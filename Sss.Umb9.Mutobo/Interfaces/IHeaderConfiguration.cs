using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IHeaderConfiguration
    {
        IEnumerable<NavItem> NavigationItems { get; }
        Image Logo { get; }
        Link LogoUrl { get; }
        IEnumerable<PoCo.Language> Languages { get; }
        Image StageImage { get; }
    }
}
