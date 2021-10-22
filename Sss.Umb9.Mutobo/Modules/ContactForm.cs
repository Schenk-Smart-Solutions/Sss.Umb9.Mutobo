using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sss.Umb9.Mutobo.Configuration;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class ContactForm : MutoboContentModule, IModule
    {

        public ContactFormData Data { get; set; }

        public IPublishedContent TargetPage { get; set; }

        public MailConfiguration SenderMailConfig => this.HasValue(DocumentTypes.ContactForm.Fields.SenderMailConfiguration) ?
            new MailConfiguration(this.Value<IPublishedContent>(DocumentTypes.ContactForm.Fields.SenderMailConfiguration)) : null; 
        public MailConfiguration ReceiverMailConfig => this.HasValue(DocumentTypes.ContactForm.Fields.ReceiverMailConfiguration) ?
            new MailConfiguration(this.Value<IPublishedContent>(DocumentTypes.ContactForm.Fields.ReceiverMailConfiguration)) : null;

        public ContactForm(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public async Task<IHtmlContent> RenderModule(IHtmlHelper helper)
        {
            return await helper.PartialAsync("~/Views/Modules/ContactForm.cshtml", this, helper.ViewData);
        }


    }
}
