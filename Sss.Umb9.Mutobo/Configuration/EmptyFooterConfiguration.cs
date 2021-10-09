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
    public class EmptyFooterConfiguration : IFooterConfiguration
    {
        public IEnumerable<FooterNavBlock> FooterNavBlocks { get; set; }
        public IEnumerable<Link> FooterLinks { get; set; }
        public IEnumerable<FooterContactArea> FooterContactBlock { get; set; }
        public IEnumerable<PoCo.Language> Languages { get; set; }
        public IEnumerable<PictureLink> PictureLinks { get; set; }
        public Image HomePageLogo { get; set; }
        public string Copyright { get; set; }
        public IEnumerable<Link> BlockLinks { get; set; }
        public string Theme { get; set; }
    }
}
