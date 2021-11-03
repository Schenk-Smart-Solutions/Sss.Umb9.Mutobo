using Microsoft.AspNetCore.Html;
using Sss.Umb9.Mutobo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface ITheme
    {
        EPageTheme PageTheme { get; }
        string BackgroundColor { get; }
        string ColorHover { get; }
        string ColorSecondary { get; }
        string Color { get; }
        string FooterBackgroundColor { get; }
        string FooterColorHover { get; }
        string FooterColor { get; }
        string HeaderBackgroundColor { get; }
        string HeaderColor { get; }
        string NavigationBackgroundColor { get; }
        string NavigationColorHover { get; }
        string NavigationColor { get; }
        string NavigationHrColor { get; }
        string HrColor { get; }
        IHtmlContent GetDynamicCssProperties();
    }
}
