using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Common.Exceptions
{
    public class NavigationException : MutoboException
    {
        public NavigationException(string message) : base(message)
        {
        }
    }
}
