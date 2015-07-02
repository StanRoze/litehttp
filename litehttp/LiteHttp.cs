using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace litehttp
{
    public static class LiteHttp
    {
   
        public static IFluentLiteServer ToFluent()
        {
            return new FluentLiteHttpServer();
        }

    }
}
