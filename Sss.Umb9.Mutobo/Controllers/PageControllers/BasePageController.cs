using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
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
    public class BasePageController : RenderController
    {

        protected readonly IImageService ImageService;


        public BasePageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IImageService imageService)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            ImageService = imageService;
        }


        public override IActionResult Index()
        {
            return CurrentTemplate(CurrentPage);
        }

    }
}
