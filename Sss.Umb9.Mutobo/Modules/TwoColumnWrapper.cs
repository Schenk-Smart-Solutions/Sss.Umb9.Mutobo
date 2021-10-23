using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class TwoColumnWrapper : MutoboContentModule, IModule
    {

        public IEnumerable<IWrappable> Elements { get; set; }


        public TwoColumnWrapper(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }


        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            var bld = new StringBuilder();
            return await helper.PartialAsync("~/Views/Modules/TwoColumnWrapper.cshtml", this);
        }
    }
}
