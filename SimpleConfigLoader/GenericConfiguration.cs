using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleConfigLoader
{
    public class GenericConfiguration : Dictionary<string, object>
    {
        public T? GetValue<T>(string key)
        {
            if (this.ContainsKey(key) == false)
            {
                return default(T);
            }

            var val = this[key];

            try
            {
                return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(val));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

    }
}
