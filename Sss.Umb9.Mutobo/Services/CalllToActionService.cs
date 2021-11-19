using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class CalllToActionService : BaseService, ICallToActionService
    {
        public CalllToActionService(
            ILogger<CalllToActionService> logger, 
            IUmbracoContextAccessor contextAccessor) : base(logger, contextAccessor)
        {


        }

        public CallToActionButton GetCtaButton(IPublishedContent content)
        {
            List<IPublishedContent> pages = content
                .AncestorsOrSelf()
                .ToList();

            CallToActionButton ctaButton = null;
            var index = 0;


            if (pages != null)
            {
                do
                {
                    ctaButton = pages[index].HasValue(DocumentTypes.BasePage.Fields.CallToActionButton)
                        ? new CallToActionButton(pages[index].Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.CallToActionButton).FirstOrDefault(), null) : null;
                    index++;

                } while (index < pages.Count() && ctaButton == null);
            }

            return ctaButton;
        }
    }
}
