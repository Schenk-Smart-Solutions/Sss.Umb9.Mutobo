using Sss.Umb9.Mutobo.Enum;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Modules
{
    public class EmptySliderComponent : ISliderComponent
    {
        public IEnumerable<ISliderItem> Slides { get; set; }
        public int? Height { get; set; }
        public int? Interval { get; set; }
        public int? Width { get; set; }
        public EGalleryType GalleryType { get; set; }


        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";


            if (GalleryType == EGalleryType.Boxed)
                result = "picture-";


            return result;
        }

        public EmptySliderComponent()
        {

        }
    }
}
