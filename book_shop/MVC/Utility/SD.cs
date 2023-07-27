namespace MVC.Utility
{
    public class SD
    {
        public static string AuthApiBase { get; set; }
        public static string CatalogApiBase { get; set; }
        public static string BasketApiBase { get; set; }
        public static string OrderApiBase { get; set; }
        public const string TokenCookie = "JWTToken"; 
        public enum ApiType
        {
            GET,
            POST, 
            PUT,
            DELETE
        }
    }
}
