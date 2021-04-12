using System;
using System.Collections.Generic;
using System.Linq;

namespace caixa_eletronico.Services.Extensions
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(x => (T) x.Clone()).ToList();
        }
    }
}
