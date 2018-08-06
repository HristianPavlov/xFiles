using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xFile.Common.Exeptions
{
    public class ThereIsACountryWithTheSameNameAsTheCitry:Exception
    {
        public ThereIsACountryWithTheSameNameAsTheCitry()
        {
        }

        public ThereIsACountryWithTheSameNameAsTheCitry(string message)
            : base(message)
        {
        }

        public ThereIsACountryWithTheSameNameAsTheCitry(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
