using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using litehttp.Http;

namespace litehttp.Framework
{
    internal static class LiteRequestConverter
    {
        public static LiteRequest FromHttpListenerRequest(HttpListenerRequest request)
        {
            return new LiteRequest();
        }
    }
}
