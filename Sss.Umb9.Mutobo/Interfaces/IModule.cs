using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IModule
    {
        string ModuleTitle { get; }
        bool SpacerAfterModule { get; }
        IHtmlContent RenderModule(IHtmlHelper helper);
    }
}
