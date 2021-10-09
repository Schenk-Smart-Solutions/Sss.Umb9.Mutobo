using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.PageModels
{
    public class ContentPage : ArticlePage
    {
        public IEnumerable<IModule> Modules { get; set; }


        public ContentPage(IPublishedContent content) : base(content)
        {
        }
    }
}
