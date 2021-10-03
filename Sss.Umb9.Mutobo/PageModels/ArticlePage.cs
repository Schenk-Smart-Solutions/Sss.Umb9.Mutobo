using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PageModels
{
    public class ArticlePage : BasePage
    {
        public string Abstract => Content.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract);
        public bool HideAbstract => Content.Value<bool>(DocumentTypes.ArticlePage.Fields.HideAbstract);
        public string MainContent => Content.Value<string>(DocumentTypes.ArticlePage.Fields.MainContent);
        public IEnumerable<Image> EmotionImages { get; set; }


        public ArticlePage(IPublishedContent content) 
            : base(content)
        {
        }
    }
}
