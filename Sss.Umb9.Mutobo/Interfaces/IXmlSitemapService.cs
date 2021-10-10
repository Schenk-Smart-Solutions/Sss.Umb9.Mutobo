using Sss.Umb9.Mutobo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IXmlSitemapService
    {
        IEnumerable<BasePage> GetXmlSitemap(IPublishedContent model);
    }
}
