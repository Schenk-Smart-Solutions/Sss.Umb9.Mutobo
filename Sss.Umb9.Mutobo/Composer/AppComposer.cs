using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Components;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;


namespace Sss.Umb9.Mutobo.Composer
{
    public class AppComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            AddComponents(builder);
            RegisterServices(builder);
        }


        private void AddComponents(IUmbracoBuilder builder)
        {
            builder.Components().Append<MinifierComponent>();
            builder.Components().Append<SearchConfigurationComponent>();
            //composition.Components().Append<HtmlMinifierComponent>();
            //composition.Components().Append<CustomDropDownPopulateComponent>();
            //composition.Components().Append<CustomIndexComponent>();
        }

        private void RegisterServices(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<IImageService, ImageService>();
            builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
            builder.Services.AddTransient<IMutoboContentService, MutoboContentService>();
            builder.Services.AddScoped<ISeoService, SeoService>();
            builder.Services.AddScoped<IXmlSitemapService, XmlSitemapService>();
            builder.Services.AddSingleton<ICardService, CardService>();
            builder.Services.AddSingleton<ISliderService, SliderService>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddSingleton<IFlyerservice, FlyerService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IPageLayoutService, PageLayoutService>();
            builder.Services.AddSingleton<IPictureLinkService, PictureLinkService>();
            builder.Services.AddScoped<ISearchService, SearchService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>(); 
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<ICallToActionService, CalllToActionService>();
            builder.Services.AddSingleton<IThemeService, ThemeService>();
        }
    }
}
