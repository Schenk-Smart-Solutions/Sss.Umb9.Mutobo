using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Controllers.PageControllers
{
    public class ArticlePageController : BasePageController
    {
       

        public ArticlePageController(
            ILogger<RenderController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor,
            IImageService imageService,
            IPageLayoutService pageLayoutService,
            IMutoboContentService contentService) 
            : base(logger, compositeViewEngine, umbracoContextAccessor, imageService, pageLayoutService, contentService)
        {

          
        }


    }
}
