using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface ISliderService
    {
        IEnumerable<ISliderItem> GetSlides(IPublishedElement content, string fieldName, int? width = null,
    int? height = null, bool isGoldenRatio = false);

        IEnumerable<TextImageSlide> GetDoubleSlides(IPublishedElement content, string fieldName, int? width = null,
       int? height = null, bool isGoldenRatio = false);
    }
}
