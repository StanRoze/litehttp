using System;
using System.Collections.Generic;

namespace litehttp.Middleware
{
    public class MiddleWareCollection 
    {
        readonly List<Type> _middleWares = new List<Type>(); 
        public void Add<T>() where T:LiteMiddleWare
        {
            _middleWares.Add(typeof(T));
        }

        private LiteMiddleWare Next(int i)
        {
            if (i == _middleWares.Count - 1)
            {
                return (LiteMiddleWare)Activator.CreateInstance(_middleWares[i], LiteMiddleWare.Empty);
            }

            return (LiteMiddleWare)Activator.CreateInstance(_middleWares[i], Next(i+1));
        }

        internal LiteMiddleWare Create()
        {
            return Next(0);
        }
    }
}