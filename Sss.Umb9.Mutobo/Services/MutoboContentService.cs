using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Extensions;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.Modules;
using Sss.Umb9.Mutobo.PageModels;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
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
            IImageService imageService,
            ISliderService sliderService,
            ICardService cardService,
            IUmbracoContextAccessor contextAccessor)
                : base(logger, contextAccessor)
        {
            SliderService = sliderService;
            _cardService = cardService;
            ImageService = imageService;
        }

        private IEnumerable<IModule> GetContent(IPublishedContent content, string fieldName)
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
                        case DocumentTypes.VideoComponent.Alias:
                            result.Add(new VideoComponent(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.RichTextComponent.Alias:
                            result.Add(new RichtextComponent(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.Flyer.Alias:
                            result.Add(new Flyer(element.value, null)
                            {
                                SortOrder = element.index,
                                Image = element.value.HasValue(DocumentTypes.Flyer.Fields.FlyerImage) ? ImageService
                                .GetImage(element.value.Value<IPublishedContent>(DocumentTypes.Flyer.Fields.FlyerImage),
                                width: 900,
                                imageCropMode: ImageCropMode.Max)
                                : null,
                                TeaserText = element.value.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText),
                                Link = element.value.Value<Link>(DocumentTypes.Flyer.Fields.Link)

                            });
                            break;

                        case DocumentTypes.Teaser.Alias:
                            result.Add(GetTeaser(element.value, element.index));
                            break;
                        case DocumentTypes.SliderComponent.Alias:
                            var sliderModule = new SliderComponent(element.value, null)
                            {
                                SortOrder = element.index
                            };

                            var useGoldenRatio = (sliderModule.Height == null && sliderModule.Width == null);


                            sliderModule.Slides = SliderService.GetSlides(element.value,
                                DocumentTypes.SliderComponent.Fields.Slides, sliderModule.Width, sliderModule.Height);
                            result.Add(sliderModule);
                            break;



                        case DocumentTypes.PictureModule.Alias:
                            var picModule = new PictureModule(element.value, null)
                            {
                                SortOrder = element.index
                            };
                            var isGoldenRatio = (picModule.Height == null && picModule.Width == null);
                            picModule.Image = element.value.HasValue(DocumentTypes.Picture.Fields.Image)
                                ? ImageService.GetImage(
                                    element.value.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image),
                                    height: 450,
                                    width: 800)
                                : null;
                            result.Add(picModule);
                            break;

                        //case DocumentTypes.Newsletter.Alias:
                        //    result.Add(new Newsletter(element.value)
                        //    {
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        case DocumentTypes.BlogModule.Alias:
                            var model = new BlogModule(element.value, null)
                            {
                                SortOrder = element.index
                            };

                            model.BlogEntries = model.ParentPage != null ?
                                model.ParentPage.Children.Select(c => new ArticlePage(c) {
                                    EmotionImages = c.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                                    ImageService.GetImages(c.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages)) : null
                                }) 
                                : CurrentPage.Children.Select(c => new ArticlePage(c) {
                                    EmotionImages = c.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                                    ImageService.GetImages(c.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages)) : null
                                });

                           
                            result.Add(model);
                            break;
                        case DocumentTypes.Accordeon.Alias:
                            result.Add(new Accordeon(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.DoubleSliderComponent.Alias:
                            var dblSliderComponent =  new DoubleSliderComponent(element.value, null)
                            {
                                
                                SortOrder = element.index
                            };
                            dblSliderComponent.Slides = SliderService.GetDoubleSlides(element.value, DocumentTypes.DoubleSliderComponent.Fields.Slides, width: dblSliderComponent.Width, height: dblSliderComponent.Height) as IEnumerable<TextImageSlide>;
                            result.Add(dblSliderComponent);
                            break;
                        case DocumentTypes.Quote.Alias:
                            result.Add(new Quote(element.value, null)
                            {
                                SortOrder = element.index
                            });
                            break;
                        //case DocumentTypes.CardContainer.Alias:
                        //    result.Add(new CardContainer(element.value, null)
                        //    {
                        //        Cards = _cardService.GetCards(element.value, Constants.DocumentTypes.CardContainer.Fields.Cards),
                        //        // set the sort order of the module to ensure the module order
                        //        SortOrder = element.index
                        //    });
                        //    break;
                        case DocumentTypes.ContactForm.Alias:
                            var contactFormModel = new ContactForm(element.value, null);

                            contactFormModel.Data = new ContactFormData
                            {
                                ReceiverMailConfigId = contactFormModel.ReceiverMailConfig.Content.Id,
                                SenderMailConfigId = contactFormModel.SenderMailConfig.Content.Id,
                                LandingPageId = contactFormModel.LandingPage.Key
                            };

                            result.Add(contactFormModel);
                            break;
                        case DocumentTypes.TwoColumnWrapper.Alias:
                            var twoColModel = new TwoColumnWrapper(element.value, null);

                            var childElements = element.value.HasValue(DocumentTypes.TwoColumnWrapper.Fields.Elements) ?
                                element.value.Value<IEnumerable<IPublishedElement>>(DocumentTypes.TwoColumnWrapper.Fields.Elements) 
                                : null;

                            var childModules = new List<IWrappable>();
                            foreach (var childElement in childElements)
                            {
                                switch (childElement.ContentType.Alias)
                                {
                                    case DocumentTypes.FlipTeaser.Alias:
                                        var flipTeaser = new FlipTeaser(childElement, null);
                                        flipTeaser.Image = childElement.HasValue(DocumentTypes.FlipTeaser.Fields.FrontImage) ?
                                            ImageService.GetImage(childElement.Value<IPublishedContent>(DocumentTypes.FlipTeaser.Fields.FrontImage), height: 300, width: 300) : null;
                                        childModules.Add(flipTeaser);
                                        break;
                                }
                                
                            }
                            twoColModel.Elements = childModules;
                            result.Add(twoColModel);


                            break;
                    }
                }

                return result;
            }

            return null;
        }

        public BasePage GetPageModel(IPublishedContent content)
        {
            switch (content.ContentType.Alias)
            {
                case DocumentTypes.BasePage.Alias:
                default:
                    return new BasePage(content);

                case DocumentTypes.ArticlePage.Alias:


                    return new ArticlePage(content)
                    {
                        EmotionImages = CurrentPage.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                        ImageService.GetImages(CurrentPage.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages),
                        width: 800,
                        height: 450) : null,
                       
                    };

                case DocumentTypes.ContentPage.Alias:
                    return new ContentPage(content)
                    {
                        EmotionImages = CurrentPage.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                        ImageService.GetImages(CurrentPage.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages),
                        width: 800,
                        height: 450) : null,
                        Modules = CurrentPage.HasValue(DocumentTypes.ContentPage.Fields.Modules) ? GetContent(CurrentPage, DocumentTypes.ContentPage.Fields.Modules) : null
                    };

                case DocumentTypes.HomePage.Alias:
                    return new HomePage(content) 
                    { 
                        Modules = CurrentPage.HasValue(DocumentTypes.HomePage.Fields.Modules) ? GetContent(CurrentPage, DocumentTypes.HomePage.Fields.Modules) : null
                    };
            }


        }

        private Teaser GetTeaser(IPublishedElement element, int index)
        {

            var teaser = new Teaser(element, null)
            {
                SortOrder = index
            };


            if (teaser.UseArticleData)
            {
                var article = teaser.Link?.Udi != null ?
                    new ArticlePage(Context.Content.GetById(teaser.Link.Udi)) : null;

                if (article == null)
                    throw new Exception($"Please make sure that you have a linked article page when using article data.");

                teaser.Images = GetHighlightImages(article.Content);

                teaser.TeaserText = GetHighlightText(article.Content);
                teaser.TeaserTitle = GetHighlightTitle(article.Content);
            }
            else
            {
                teaser.Images = element.HasValue(DocumentTypes.Teaser.Fields.Images)
                    ? ImageService.GetImages(
                        element.Value<IEnumerable<IPublishedContent>>(DocumentTypes.Teaser.Fields.Images), width: 800, height: 450)
                    : null;
                teaser.TeaserText = element.HasValue(DocumentTypes.Teaser.Fields.TeaserText) ?
                    element.Value<string>(DocumentTypes.Teaser.Fields.TeaserText) : null;

                teaser.TeaserTitle = element.HasValue(DocumentTypes.Teaser.Fields.TeaserTitle) ?
                    element.Value<string>(DocumentTypes.Teaser.Fields.TeaserTitle) : null;
            }


            return teaser;

        }

        private string GetHighlightText(IPublishedContent content)
        {
            string result = null;

            if (content.HasValue(DocumentTypes.ArticlePage.Fields.Abstract))
                result = content.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract);


            return result;
        }

        private string GetHighlightTitle(IPublishedContent content)
        {
            string result = null;


            if (content.HasValue(DocumentTypes.BasePage.Fields.PageTitle))
                result = content.Value<string>(DocumentTypes.BasePage.Fields.PageTitle);

            return result;
        }


        private IEnumerable<Image> GetHighlightImages(IPublishedContent content)
        {
            var result = new List<Image>();

            if (content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages))
                result.AddRange(ImageService.GetImages(content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages), width: 800, height: 450));

            return result;
        }
    }
}
