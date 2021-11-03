using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class ThemeService : BaseService, IThemeService
    {

        public ThemeService(ILogger<ThemeService> logger, IUmbracoContextAccessor contextAccessor) : base(logger, contextAccessor)
        {
        }

        public virtual ITheme GetTheme(IPublishedContent content)
        {

            var theme = content?.AncestorsOrSelf()?
                .FirstOrDefault(c => c.HasValue(DocumentTypes.BasePage.Fields.Theme))?
                .Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.Theme)?
                .FirstOrDefault();

            if (theme != null)
                return new Theme(theme, null);

            return null;
        }



        public IEnumerable<Font> GetFonts()
        {
            var result = new List<Font>();
            //var wcDirectory = HttpContext.Current.Server.MapPath($"~/{_configurationService.GetAppSettingValue("Toolbox.WebComponentsFontsFolder")}");
            //var di = new DirectoryInfo(wcDirectory);
            //var i = 0;
            //var fonts = di.GetFiles("*.woff", SearchOption.AllDirectories)
            //    .Concat(di.GetFiles("*.woff2", SearchOption.AllDirectories))
            //    .Concat(di.GetFiles("*.eot", SearchOption.AllDirectories))
            //    .Concat(di.GetFiles("*.TTF", SearchOption.AllDirectories))
            //    .Concat(di.GetFiles("*.svg", SearchOption.AllDirectories));


            //var fileInfos = fonts as FileInfo[] ?? fonts.ToArray();
            //foreach (var font in fileInfos)
            //{
            //    var fontName = font.Name.Split('.')[0];
            //    result.Add(new Font
            //    {
            //        Name = fontName,
            //        Files = fileInfos.Where(f => f.Name.StartsWith(fontName))
            //    });
            //    i++;
            //}

            return result;
        }


    }

}
