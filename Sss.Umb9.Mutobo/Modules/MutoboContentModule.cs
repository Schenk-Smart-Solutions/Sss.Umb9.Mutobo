using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Sss.Umb9.Mutobo.Modules
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {
        public string ModuleTitle => this.HasValue(Constants.Compositions.Module.Fields.ModuleTitle)
            ? this.Value<string>(Constants.Compositions.Module.Fields.ModuleTitle) : null;


        public bool SpacerAfterModule => this.Value<bool>(Constants.Compositions.Module.Fields.SpacerAfterModule);

        public bool SpacerBeforeModule => this.Value<bool>(Constants.Compositions.Module.Fields.SpacerBeforeModule);

        public int SortOrder { get; set; }

        public MutoboContentModule(
            IPublishedElement content,
            IPublishedValueFallback publishedValueFallback)
            : base(content, publishedValueFallback)
        {
        }

 
    }
}
