using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.UmbracoContext;

namespace Sss.Umb9.Mutobo.Services
{
    public abstract class BaseService
    {
 
        protected readonly ILogger Logger;
        protected readonly IUmbracoContextAccessor ContextAccessor;
        protected readonly IUmbracoContext Context;
        protected readonly IPublishedContent CurrentPage;



        protected BaseService(ILogger logger, IUmbracoContextAccessor contextAccessor)
        {
            Logger = logger;
            ContextAccessor = contextAccessor;

            if (ContextAccessor.TryGetUmbracoContext(out Context)) 
            {
                CurrentPage = Context.PublishedRequest.PublishedContent;
            }
        }

    }
}
