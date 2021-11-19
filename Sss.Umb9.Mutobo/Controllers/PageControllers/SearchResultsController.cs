using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Sss.Umb9.Mutobo.Controllers.PageControllers
{
    public class SearchResultsController : BasePageController
    {
        public SearchResultsController(
            ILogger<SearchResultsController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor, 
            IImageService imageService, 
            IPageLayoutService pageLayoutService, 
            IMutoboContentService contentService,
            ICallToActionService callToActionService) : base(
                logger, 
                compositeViewEngine, 
                umbracoContextAccessor, 
                imageService, 
                pageLayoutService, 
                contentService,
                callToActionService)
        {
        }
    }
}
