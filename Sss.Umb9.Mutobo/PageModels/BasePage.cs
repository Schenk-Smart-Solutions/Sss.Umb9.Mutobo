using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PageModels
{





    public class BasePage : ContentModel
    {
        public BasePage(IPublishedContent content) : base(content)
        {
        }

        public CallToActionButton CallToActionButton { get; set; }
        public IHeaderConfiguration HeaderConfiguration { get; set; }
        public IFooterConfiguration FooterConfiguration { get; set; }

        public string PageTitle => Content.Value<string>(DocumentTypes.BasePage.Fields.PageTitle);

        public bool HideFromNavigation => Content.Value<bool>(DocumentTypes.BasePage.Fields.HideFromNavigation);

        public bool NotClickable => Content.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable);

        public Link RedirectLink => Content.Value<Link>(DocumentTypes.BasePage.Fields.RedirectLink);

        public string MetaTitle => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaTitle);
        public string MetaDescription => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaDescription);
        public string MetaKeywords => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaKeywords);
        public bool ExcludeFromXMLSitemap => Content.Value<bool>(DocumentTypes.BasePage.Fields.ExcludeFromXMLSitemap);
        public string SearchEngineFrequency => Content.HasValue(DocumentTypes.BasePage.Fields.SearchEngineFrequency) ? Content.Value<string>(DocumentTypes.BasePage.Fields.SearchEngineFrequency) : string.Empty;
        public string SearchEngineRelativePriority => Content.HasValue(DocumentTypes.BasePage.Fields.SearchEngineRelativePriority) ? Content.Value<string>(DocumentTypes.BasePage.Fields.SearchEngineRelativePriority) : string.Empty;
        public string GoogleAnalyticsKey { get; set; }
        public ITheme Theme { get; set; }
        public bool ExcludeFromSearch => Content.Value<bool>(DocumentTypes.BasePage.Fields.ExcludeFromSearch);
    }
}
