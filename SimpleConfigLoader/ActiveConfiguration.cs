using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConfigLoader
{
    public static class ActiveConfiguration
    {
        public static GenericConfiguration? Generic { get; set; }
        public static object? Specific { get; set; }

        internal static void Reset()
        {
            Generic = null;
            Specific = null;
        }
    }
}
