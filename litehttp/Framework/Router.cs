using System;
using System.Collections.Generic;
using litehttp.Http;

namespace litehttp.Framework
{
    public class Router : ILiteRouter
    {
        private readonly List<Action<LiteRequest, LiteResponse>> _middleWare;

        public Router()
        {
            _middleWare = new List<Action<LiteRequest, LiteResponse>>();
        }

        public void AddRoute<T>(string path, Func<T> executor)
        {
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }
        }

        public void Use(Action<Http.LiteRequest, Http.LiteResponse> middleware)
        {
            _middleWare.Add(middleware);
        }


        public IEnumerable<Action<LiteRequest, LiteResponse>> GetMiddleWare()
        {
            return _middleWare;
        }
    }
   
}
