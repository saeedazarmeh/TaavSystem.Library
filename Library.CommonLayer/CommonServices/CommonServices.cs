using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.CommonServices
{
    public static class CommonServices
    {
        public static string RemoveWhithSapases(this string phrase)
        {
            phrase = phrase.Trim();
            return phrase;
        }
    }
}
