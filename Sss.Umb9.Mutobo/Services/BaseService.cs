using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.UmbracoContext;

namespace Sss.Umb9.Mutobo.Services
{
    public abstract class BaseService
    {
 
        protected readonly ILogger Logger;



        protected BaseService(ILogger logger)
        {
            //Context = context;
     
        }

    }
}
