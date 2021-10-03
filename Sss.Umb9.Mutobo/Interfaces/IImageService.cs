using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IImageService
    {
        Image GetImage(
            IPublishedContent node, 
            int? width = null, 
            int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, 
            string nameSpace = "picture", 
            bool isGoldenRatio = false);

        IEnumerable<Image> GetImages(
            IEnumerable<IPublishedContent> 
            contentNodes, 
            int? width = null, 
            int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, 
            string nameSpace = "picture", 
            bool isGoldenRatio = false);
    }


}
