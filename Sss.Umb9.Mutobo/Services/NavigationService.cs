﻿using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Common.Exceptions;
using Sss.Umb9.Mutobo.Constants;
using Sss.Umb9.Mutobo.Extensions;
using Sss.Umb9.Mutobo.Interfaces;
using Sss.Umb9.Mutobo.PageModels;
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
    public class NavigationService : BaseService, INavigationService
    {
        public NavigationService(ILogger<NavigationService> logger, IUmbracoContextAccessor contextAccessor)
            : base(logger, contextAccessor)
        {
           
        }


        /// <summary>
        /// Return all pages bases on the  documentType "basePage" mapped
        /// on an IEnumerable of NavItem objects. All pages with a HideONNavigation flag
        /// will be filtered out of the result set.
        /// </summary>
        /// <returns>IEnumarable of NavItem</returns>
        public IEnumerable<NavItem> GetNavigation()
        {
            var result = new List<NavItem>();
            var homePage = DetermineHomeNode();

            if (homePage == null)
                throw new NavigationException("No Node found");

            if (homePage.Children != null && homePage.Children.Any())
            {
                foreach (var childNode in homePage.Children.Where(n => n.IsComposedOf(DocumentTypes.BasePage.Alias)))
                {
                    if (!childNode.Value<bool>(DocumentTypes.BasePage.Fields.HideFromNavigation))
                    {
                        result.Add(MapNode(childNode));
                    }
                }
            }

            return result;
        }

        private NavItem MapNode(IPublishedContent parentNode)
        {
            var result = new NavItem()
            {
                Title = parentNode.Name,
                Url = parentNode.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable) ? "#" : parentNode.GetDitUrl(),
                NewWindow = parentNode.GetOpenInNewWindowFlag(),
                IsSearchPage = parentNode.ContentType.Alias == DocumentTypes.SearchResults.Alias
            };

            var childNavItems = new List<NavItem>();

            foreach (var childNode in parentNode.Children.Where(c => !(new BasePage(c)).HideFromNavigation))
            {
                if (childNode.IsComposedOf(DocumentTypes.BasePage.Alias))
                {
                    childNavItems.Add(new NavItem()
                    {
                        Title = childNode.Name,
                        Url = childNode.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable) ? "#" : childNode.GetDitUrl(),
                        NewWindow = childNode.GetOpenInNewWindowFlag(),
                        IsSearchPage = childNode.ContentType.Alias == DocumentTypes.SearchResults.Alias
                    });
                }
            }

            result.Children = childNavItems;
            return result;
        }



        private IPublishedContent DetermineHomeNode()
        {
   
            IPublishedContent node = Context.PublishedRequest.PublishedContent;

            

            while (node.Parent != null)
            {
                node = node.Parent;

            }

            return node;
        }


    }
}
