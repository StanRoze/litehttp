using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litehttp
{
    public class Router
    {

        public void AddRoute<T>(string path, Func<T> executor)
        {
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }

           
        }

        public void AddRoute<RequestType, ResponseType>(string path, Func<RequestType, ResponseType> executor)
        {
            
        }

        private void AddValueTypeRoute<T>(string path, Func<T> executor) where T : struct 
        {
            
        }
    }


    internal abstract class Executor
    {
        public abstract object Execute();
    }

    internal class Executor<T> : Executor where T : class
    {
        private readonly Func<T> _func;

        public Executor(Func<T> func)
        {
            _func = func;
        }

        public override object Execute()
        {
            return _func();
        }


    }
}
