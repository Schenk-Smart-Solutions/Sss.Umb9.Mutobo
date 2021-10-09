using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IFooterConfiguration
    {
        IEnumerable<FooterNavBlock> FooterNavBlocks { get; }
        IEnumerable<Link> FooterLinks { get; }
        IEnumerable<FooterContactArea> FooterContactBlock { get; }
        IEnumerable<PoCo.Language> Languages { get; }
        IEnumerable<PictureLink> PictureLinks { get; }
        Image HomePageLogo { get; set; }
        string Copyright { get; }
        IEnumerable<Link> BlockLinks { get; }
        string Theme { get; }
    }
}
