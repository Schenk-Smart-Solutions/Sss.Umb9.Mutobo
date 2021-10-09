using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.PoCo
{
    public class PersonalCard : Card
    {
        public PersonalCard(IPublishedElement content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public string Lastname => this.HasValue(DocumentTypes.PersonalCard.Fields.Lastname)
    ? this.Value<string>(DocumentTypes.PersonalCard.Fields.Lastname)
    : null;
        public string Firstname => this.HasValue(DocumentTypes.PersonalCard.Fields.Firstname)
            ? this.Value<string>(DocumentTypes.PersonalCard.Fields.Firstname)
            : null;
        public string Function => this.HasValue(DocumentTypes.PersonalCard.Fields.Function)
            ? this.Value<string>(DocumentTypes.PersonalCard.Fields.Function)
            : null;

        public string Description => this.HasValue(DocumentTypes.PersonalCard.Fields.Description)
            ? this.Value<string>(DocumentTypes.PersonalCard.Fields.Description)
            : null;

        public EPersonalCardDisplayType DisplayType => this.HasValue(DocumentTypes.PersonalCard.Fields.DisplayType) && !string.IsNullOrEmpty(this.Value<string>(DocumentTypes.PersonalCard.Fields.DisplayType)?.Trim())
    ? (EPersonalCardDisplayType)System.Enum.Parse(typeof(EPersonalCardDisplayType),
        this.Value<string>(DocumentTypes.PersonalCard.Fields.DisplayType)) : EPersonalCardDisplayType.Compact;

        public bool IsMainPerson => this.Value<bool>(DocumentTypes.PersonalCard.Fields.IsMainPerson);
    }
}
