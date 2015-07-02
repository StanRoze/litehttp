using System;
using System.Collections.Generic;

namespace litehttp
{
    public class LiteHttpServerConfiguration
    {
        public static LiteHttpServerConfiguration Default
        {
            get { return new LiteHttpServerConfiguration(); }
        }

        public string RootServePath { get; set; }

        internal void AddRoute<T>(string path, Func<T> executor)
        {
            throw new NotImplementedException();
        }
    }


}