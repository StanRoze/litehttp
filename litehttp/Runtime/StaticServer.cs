using System;
using System.IO;
using System.Threading.Tasks;

namespace litehttp.Runtime
{
    internal class StaticServer
    {
        private readonly Uri _path;

        public StaticServer(string path)
        {
            if (!path.EndsWith(@"\"))
            {
                path = path + @"\";
            }
            _path = new Uri(path);
        }

        public Stream Serve(Uri path)
        {
            //TODO: Figure out how to do this without a substring.
            var relativePath = path.AbsolutePath.Substring(1);
            var absolutePath = new Uri(_path, relativePath).LocalPath;
            
            
            return !File.Exists(absolutePath) ? null : File.OpenRead(absolutePath);
        }
    }
}