using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class CallToActionButton : MutoboContentModule, IModule
    {


        public string Title => this.HasValue(DocumentTypes.CallToActionButton.Fields.Title) ?
            this.Value<string>(DocumentTypes.CallToActionButton.Fields.Title) : string.Empty;

        public string Text => this.HasValue(DocumentTypes.CallToActionButton.Fields.Text) ?
            this.Value<string>(DocumentTypes.CallToActionButton.Fields.Text) : string.Empty;

        public Link Link => this.HasValue(DocumentTypes.CallToActionButton.Fields.Link) ?
            this.Value<Link>(DocumentTypes.CallToActionButton.Fields.Link) : null;


        public CallToActionButton(
            IPublishedElement content, 
            IPublishedValueFallback publishedValueFallback) 
            : base(content, publishedValueFallback)
        {



        }
    }
}
