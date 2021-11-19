using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PageModels
{
    public class HomePage : BasePage
    {
        public IEnumerable<IModule> Modules { get; set; }


        public HomePage(IPublishedContent content) : base(content)
        {
        }
    }
}
