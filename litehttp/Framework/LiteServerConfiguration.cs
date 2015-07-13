namespace litehttp.Framework
{
    public class LiteServerConfiguration
    {
        public static LiteServerConfiguration Default
        {
            get { return new LiteServerConfiguration(); }
        }

        public string RootServePath { get; set; }

       
    }


}