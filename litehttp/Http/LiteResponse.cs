namespace litehttp.Http
{
    public class LiteResponse
    {
        public int StatusCode { get; private set; }

        public LiteResponse()
        {
            
        }

        public LiteResponse(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public void Ok()
        {
            StatusCode = 200;
        }
    }
}
