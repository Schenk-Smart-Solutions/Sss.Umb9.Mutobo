using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

namespace Sss.Umb9.Mutobo.Controllers
{
    public class XmlSitemapController : RenderController
    {
        private readonly IXmlSitemapService _xmlSitemapService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public XmlSitemapController(
            ILogger<RenderController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor,
            IXmlSitemapService xmlSitemapServicecs,
            IHttpContextAccessor httpContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _xmlSitemapService = xmlSitemapServicecs;
            _httpContextAccessor = httpContextAccessor;
        }

        public override IActionResult Index()
        {
            _httpContextAccessor.HttpContext.Response.ContentType = "text/xml";
            return View("~/Views/XmlSiteMap.cshtml", _xmlSitemapService.GetXmlSitemap(CurrentPage));
        }
    }
}
