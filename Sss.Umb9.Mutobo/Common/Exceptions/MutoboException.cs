using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Common.Exceptions
{
    public class MutoboException : Exception
    {

        public MutoboException(string message)
            : base(message)
        {

        }
    }
}
