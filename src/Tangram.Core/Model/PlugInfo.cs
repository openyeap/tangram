﻿using Newtonsoft.Json;
using System;
namespace Tangram.Core
{
    public class PlugInfo
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string[] Arguments { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public static PlugInfo GetPlugInfo(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<PlugInfo>(content);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
