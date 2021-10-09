using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class PictureLinkService : BaseService, IPictureLinkService
    {
        private readonly IImageService _imageService;


        public PictureLinkService(IImageService imageService, ILogger<PictureLinkService> logger, IUmbracoContextAccessor contextAccessor)
            : base(logger, contextAccessor)
        {
            _imageService = imageService;
        }



        public IEnumerable<PictureLink> GetPictureLinks(IEnumerable<IPublishedElement> elements)
        {
            return elements.Select(e => new PictureLink(e, null)
            {
                Image = e.HasValue(DocumentTypes.PictureLink.Fields.Image) ?
                    _imageService.GetImage(e.Value<IPublishedContent>(DocumentTypes.PictureLink.Fields.Image))
                    : null
            });
        }
    }
}
