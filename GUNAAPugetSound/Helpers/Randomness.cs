using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Utilities
{
    public class Randomness
    {
        public static Func<Guid> Guid = () => System.Guid.NewGuid();
    }
}