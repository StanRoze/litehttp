using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace litehttp.Extensions
{
    public static class HttpListenerResponseExtensions
    {
        public static async Task OkAsync(this HttpListenerResponse response)
        {
            await response.SendAsync(HttpStatusCode.OK, null);
            
        }

        public static async Task OkAsync(this HttpListenerResponse response, string message)
        {
            await response.SendAsync(HttpStatusCode.OK, Encoding.UTF8.GetBytes(message));

        }

        private static async Task SendAsync(this HttpListenerResponse response, HttpStatusCode statusCode, byte[] buffer)
        {
            response.StatusCode = (int)statusCode;

            if (buffer != null)
            {
                using (var responseStream = response.OutputStream)
                {
                    response.ContentLength64 = buffer.Length;
                    await responseStream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
            
            response.Close();
        }
    }
}
