using System;
using System.Collections.Generic;
using System.Linq;

namespace TrickyBookStore.Services
{
    public static class Utilities<TNumber>
    {
        private static readonly int _idNotIncluded = 0;
        public static bool IsIncluded(IList<TNumber> array, TNumber value)
        {
            return !array.FirstOrDefault(id => id.Equals(value)).Equals(_idNotIncluded);
        }
    }
}
