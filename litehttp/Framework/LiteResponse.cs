using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace litehttp.Framework
{
    internal class LiteResponse : ILiteResponse
    {
        private readonly HttpListenerResponse _originalResponse;
        private readonly Stream _originalStream;

        public int StatusCode
        {
            get { return _originalResponse.StatusCode; }
            set { _originalResponse.StatusCode = value; }
        }

        public System.IO.Stream Body { get; set; }

        public LiteResponse(HttpListenerResponse originalResponse)
        {
            _originalResponse = originalResponse;
            _originalStream = originalResponse.OutputStream;
        }

        public async Task CloseAsync()
        {
            try
            {
                using (_originalStream)
                using (Body)
                {
                    //if (Body.CanSeek)
                    //    Body.Seek(0, SeekOrigin.Begin);

                    await Body.CopyToAsync(_originalStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _originalResponse.Close();
            }
        }
    }
}
