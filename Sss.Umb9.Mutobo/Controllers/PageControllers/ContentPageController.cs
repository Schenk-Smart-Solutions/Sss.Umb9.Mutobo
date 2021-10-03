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
    public class ContentPageController : ArticlePageController
    {
        private readonly IMutoboContentService _contentService;

        public ContentPageController(
            ILogger<RenderController> logger,
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
            var model = new ContentPage(CurrentPage);

            model.EmotionImages = CurrentPage.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
            ImageService.GetImages(
             CurrentPage.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages),
             width: 500,
             height: 500) : null;
            model.Modules = _contentService.GetContent(CurrentPage, DocumentTypes.ContentPage.Fields.Modules);
            return CurrentTemplate(model);
        }

    }
}
