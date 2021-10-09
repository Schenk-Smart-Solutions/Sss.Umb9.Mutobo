using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IFlyerservice
    {
        IEnumerable<Flyer> GetFlyer(IPublishedContent node, bool firstPic = false);
    }
}
