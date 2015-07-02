using System;
using System.Collections.Generic;

namespace litehttp
{
    public class LiteHttpServerConfiguration
    {
        public static LiteHttpServerConfiguration Default
        {
            get { return null; }
        }

        public string RootServePath { get; set; }
    }


}