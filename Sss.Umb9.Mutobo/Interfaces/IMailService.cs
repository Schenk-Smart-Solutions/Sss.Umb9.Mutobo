using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IMailService
    {
        void SendConfirmationMail(ContactFormData model);
        void SendContactMail(ContactFormData model);

        
    }
}
