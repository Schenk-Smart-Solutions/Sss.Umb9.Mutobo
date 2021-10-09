using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface ISliderComponent
    {
        IEnumerable<ISliderItem> Slides { get; }
        int? Height { get; }
        int? Interval { get; }
        int? Width { get; }
        string GetPictureNameSpace();
    }
}
