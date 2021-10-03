using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class MutoboContentService : BaseService, IMutoboContentService
    {
        protected readonly IImageService ImageService;
        protected readonly ISliderService SliderService;
        protected readonly IConfigurationService ConfigurationService;
        private readonly ICardService _cardService;




        public MutoboContentService(
            ILogger<MutoboContentService> logger, 
            IImageService imageService) 
                : base(logger)
        {
            ImageService = imageService;
        }

        public IEnumerable<MutoboContentModule> GetContent(IPublishedContent content, string fieldName)
        {
            if (content.HasValue(fieldName))
            {
                var result = new List<MutoboContentModule>();

                var elements =
                    content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var element in elements.Select((value, index) => new { index, value }))
                {
                    switch (element.value.ContentType.Alias)
                    {
                        case DocumentTypes.Heading.Alias:
                            result.Add(new Heading(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        //case DocumentTypes.VideoComponent.Alias:
                        //    result.Add(new VideoComponent(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        //case DocumentTypes.RichTextComponent.Alias:
                        //    result.Add(new RichtextComponent(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        //case DocumentTypes.Flyer.Alias:
                        //    result.Add(new Flyer(element.value)
                        //    {
                        //        SortOrder = element.index,
                        //        Image = element.value.GetImage(DocumentTypes.Flyer.Fields.FlyerImage,
                        //            width: 900, imageCropMode: ImageCropMode.Max),
                        //        TeaserText = element.value.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText),
                        //        Link = element.value.Value<Umbraco.Web.Models.Link>(DocumentTypes.Flyer.Fields.Link)

                        //    });
                        //    break;

                        //case DocumentTypes.Teaser.Alias:
                        //    result.Add(GetTeaser(element.value, element.index));
                        //    break;
                        //case DocumentTypes.SliderComponent.Alias:
                        //    var sliderModule = new SliderComponent(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    };

                        //    var useGoldenRatio = (sliderModule.Height == null && sliderModule.Width == null);


                        //    sliderModule.Slides = SliderService.GetSlides(element.value,
                        //        DocumentTypes.SliderComponent.Fields.Slides, sliderModule.Width);
                        //    result.Add(sliderModule);
                        //    break;



                        //case DocumentTypes.PictureModule.Alias:
                        //    var picModule = new PictureModule(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    };
                        //    var isGoldenRatio = (picModule.Height == null && picModule.Width == null);
                        //    picModule.Image = element.value.HasValue(DocumentTypes.Picture.Fields.Image)
                        //        ? ImageService.GetImage(
                        //            element.value.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image),
                        //            height: picModule.Height,
                        //            width: picModule.Width)
                        //        : null;
                        //    result.Add(picModule);
                        //    break;

                        //case DocumentTypes.Newsletter.Alias:
                        //    result.Add(new Newsletter(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        case DocumentTypes.BlogModule.Alias:
                            result.Add(new BlogModule(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.Accordeon.Alias:
                            result.Add(new Accordeon(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        //case DocumentTypes.Quote.Alias:
                        //    result.Add(new Quote(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        //case DocumentTypes.CardContainer.Alias:
                        //    result.Add(new CardContainer(element.value)
                        //    {
                        //        Cards = _cardService.GetCards(element.value, Constants.DocumentTypes.CardContainer.Fields.Cards),
                        //        // set the sort order of the module to ensure the module order
                        //        SortOrder = element.index
                        //    });
                        //    break;
                    }
                }

                return result;
            }

            return null;
        }
    }
}
