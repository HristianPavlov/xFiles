using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XFiles.Exeptions
{
   
    public class ThereIsACityWithTheSameNameAsTheCountry : Exception
    {
    
        public ThereIsACityWithTheSameNameAsTheCountry()
        {
        }

        public ThereIsACityWithTheSameNameAsTheCountry(string message)
            : base(message)
        {
        }

        public ThereIsACityWithTheSameNameAsTheCountry(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}