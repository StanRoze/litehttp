using System;
using litehttp.Http;

namespace litehttp.Runtime
{
    public class LiteServerConfiguration
    {
        public static LiteServerConfiguration Default
        {
            get { return new LiteServerConfiguration(); }
        }

        public string RootServePath { get; set; }

       
    }


}