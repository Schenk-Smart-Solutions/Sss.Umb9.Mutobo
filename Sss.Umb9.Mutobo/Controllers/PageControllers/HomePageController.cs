using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using Sss.Umb9.Mutobo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Sss.Umb9.Mutobo.Controllers.PageControllers
{
    public class HomePageController : BasePageController
    {
        private readonly IMutoboContentService _contentService;
        public IEnumerable<MutoboContentModule> Modules { get; set; }
        public HomePageController(
            ILogger<HomePageController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor, 
            IImageService imageService,
            IMutoboContentService contentService) 
                : base(logger, compositeViewEngine, umbracoContextAccessor, imageService)
        {
            _contentService = contentService;
        }

        public override IActionResult Index()
        {
            var model = new HomePage(CurrentPage);
            model.Modules = _contentService.GetContent(CurrentPage, DocumentTypes.HomePage.Fields.Modules);
            return CurrentTemplate(model);
        }
    }
}
