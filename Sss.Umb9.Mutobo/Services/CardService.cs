using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Services
{
    public class CardService :  ICardService
    {
        private readonly IImageService _imageService;

        public CardService(IImageService imageService) 
        {
            
            _imageService = imageService;
        }

        public IEnumerable<Card> GetCards(IPublishedElement element, string fieldName)
        {
            if (!element.HasValue(fieldName))
                return null;

            var result = element.Value<IEnumerable<IPublishedContent>>(fieldName)
                .Where(c => c.ContentType.Alias == DocumentTypes.Card.Alias).Select((element, index) => new
                {
                    element = new Card(element, null)
                    {
                        SortOrder = index,
                        Image = element.HasValue(DocumentTypes.Card.Fields.Image)
                            ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image), 850,
                                450, ImageCropMode.Crop)
                            : null
                    },
                    index
                }).Select(e => e.element).ToList();

            result.AddRange(element.Value<IEnumerable<IPublishedContent>>(fieldName)
                .Where(c => c.ContentType.Alias == DocumentTypes.PersonalCard.Alias)
                .Select((element, index) => new
                {
                    element = new PersonalCard(element, null)
                    {
                        SortOrder = index,
                        Image = element.HasValue(DocumentTypes.Card.Fields.Image)
                            ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image),
                                500, 500,
                                imageCropMode: ImageCropMode.Stretch)
                            : null
                    },
                    index
                }).Select(e => e.element));

            //result.AddRange(element.Value<IEnumerable<IPublishedContent>>(fieldName)
            //    .Where(c => c.ContentType.Alias == DocumentTypes.AppointmentCard.Alias)
            //    .Select((element, index) => new
            //    {
            //        element = new AppointmentCard(element)
            //        {
            //            SortOrder = index,
            //            Image = element.HasValue(DocumentTypes.Card.Fields.Image)
            //                ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image),
            //                    500,
            //                    500)
            //                : null
            //        },
            //        index
            //    }).Select(e => e.element));



            //result.AddRange(element.Value<IEnumerable<IPublishedContent>>(fieldName)
            //    .Where(c => c.ContentType.Alias == DocumentTypes.ProjectCard.Alias)
            //    .Select((element, index) => new
            //    {
            //        element = new ProjectCard(element)
            //        {
            //            SortOrder = index,
            //            Image = element.HasValue(DocumentTypes.Card.Fields.Image)
            //                ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image),
            //                    500,
            //                    height: 500)
            //                : null
            //        },
            //        index
            //    }).Select(e => e.element));

            return result.OrderBy(e => e.SortOrder);
        }
    }
}
