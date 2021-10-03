using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EImageDimension
    {

        Default,
        [EnumMember(Value = "small")]
        Small,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "large")]
        Large,
        [EnumMember(Value = "extra-large")]
        ExtraLarge
    }
}
