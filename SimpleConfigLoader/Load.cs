﻿using System.IO;
using System.Text.Json;

namespace SimpleConfigLoader
{
    public class Load
    {
        public static GenericConfiguration? FromRoot(string file)
        {
            var path = Environment.CurrentDirectory;

            return FromPath(Path.Combine(path, file));
        }

        public static T? FromRoot<T>(string file)
        {
            var path = Environment.CurrentDirectory;

            return FromPath<T>(Path.Combine(path, file));
        }

        public static GenericConfiguration? FromPath(string path)
        {
            return LoadFromFile<GenericConfiguration>(path);
        }

        public static T? FromPath<T>(string path)
        {
            return LoadFromFile<T>(path);
        }

        private static T? LoadFromFile<T>(string path)
        {
            var serialized = string.Empty;

            ActiveConfiguration.Reset();

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    serialized = r.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

            string ext = string.Empty;

            try
            {
                ext = Path.GetExtension(path).Trim().ToLower();
            }
            catch (Exception)
            {
            }

            T? config = default(T);

            try
            {
                if (ext == ".json")
                {
                    config = JsonSerializer.Deserialize<T>(serialized);
                }
            }
            catch (Exception)
            {

            }

            if (typeof(T) == typeof(GenericConfiguration))
            {
                ActiveConfiguration.Generic = config as GenericConfiguration;
            }
            else
            {
                ActiveConfiguration.Specific = config;
            }

            return config;
        }

        
    }
}
