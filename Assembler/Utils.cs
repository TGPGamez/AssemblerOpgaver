﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerOpgave
{
    public static class Utils
    {
        public static T2? TryGetOrDefault<T1, T2>(this Dictionary<T1, T2> dictionary, T1? key, T2? defaultValue) where T1 : notnull
        {
            if (key is null) return defaultValue;

            return dictionary.TryGetValue(key, out T2? value) ? value : defaultValue;
        }
    }
}
