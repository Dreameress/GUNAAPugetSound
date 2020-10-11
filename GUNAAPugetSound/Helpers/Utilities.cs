using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Helpers
{
    public class Utilities
    {
        public string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

    }
}
