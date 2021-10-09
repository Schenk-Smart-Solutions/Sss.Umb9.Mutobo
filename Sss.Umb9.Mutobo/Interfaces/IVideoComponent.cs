using Microsoft.AspNetCore.Html;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IVideoComponent
    {
        Video Video { get; }
        String Embedded { get; }
        String Text { get; }
        int? Width { get; }
        int? Height { get; }
        IHtmlContent RenderIFrame(int? width = null, int? height = null);
    }
}
