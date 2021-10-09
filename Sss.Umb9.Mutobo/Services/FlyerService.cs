using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Services
{
    public class FlyerService : BaseService, IFlyerservice
    {
        public FlyerService(ILogger<FlyerService> logger) : base(logger)
        {
        }

        public IEnumerable<Flyer> GetFlyer(IPublishedContent node, bool firstPic = false)
        {
            throw new NotImplementedException();
        }
    }
}
