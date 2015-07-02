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

        internal void AddRoute<T>(string path, Func<T> executor)
        {
           
        }

        private void AddRequestRoute(string path, Func<LiteResponse> executor) 
        {
            
        }
    }


}