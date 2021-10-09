using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class SliderService: ISliderService
    {

        private readonly IImageService _imageService;

        public SliderService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IEnumerable<ISliderItem> GetSlides(IPublishedElement content, string fieldName, int? width = null, int? height = null, bool isGoldenRatio = false)
        {
            var result = new List<ISliderItem>();

            if (content.HasValue(fieldName))
            {
                var slideContent = content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var slideNode in slideContent)
                {
                    if (slideNode.ContentType.Alias == DocumentTypes.VideoComponent.Alias)
                    {
                        var vc = new VideoComponent(slideNode, null);

                        result.Add(new EmptyVideoComponent()
                        {
                            Height = height,
                            Width = width,
                            Embedded = vc.Embedded,
                            Text = vc.Text,
                            Video = vc.Video
                        });
                    }
                    else if (slideNode.ContentType.Alias == DocumentTypes.Picture.Alias)
                    {
                        result.Add(new Picture()
                        {
                            Image = slideNode.HasValue(DocumentTypes.Picture.Fields.Image) ? _imageService.GetImage(
                                slideNode.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image), width, height, isGoldenRatio: isGoldenRatio) : null
                        });
                    }


                }

            }

            return result;
        }


        public IEnumerable<TextImageSlide> GetDoubleSlides(IPublishedElement content, string fieldName, int? width = null, int? height = null,
    bool isGoldenRatio = false)
        {

            var result = new List<TextImageSlide>();
            if (content.HasValue(fieldName))
            {
                var slideContent = content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var slideNode in slideContent)
                {

                    var textImageComponent = new TextImageSlide(slideNode, null);

                    result.Add(new TextImageSlide(slideNode, null)
                    {
                        Image = slideNode.HasValue(DocumentTypes.Picture.Fields.Image) ? _imageService.GetImage(
                           slideNode.Value<IPublishedContent>(DocumentTypes.TextImageSlide.Fields.Image), width, height, isGoldenRatio: isGoldenRatio) : null
                    });



                }

            }

            return result;
        }
    }
}
