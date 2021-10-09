using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface INavigationService
    {

        /// <summary>
        /// Return all pages bases on the  documentType "basePage" mapped
        /// on an IEnumerable of NavItem objects. All pages with a HideONNavigation flag
        /// will be filtered out of the result set.
        /// </summary>
        /// <returns>IEnumarable of NavItem</returns>
        IEnumerable<NavItem> GetNavigation();
    }
}
