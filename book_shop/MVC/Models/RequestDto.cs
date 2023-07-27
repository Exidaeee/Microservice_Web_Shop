using MVC.Utility;
using static MVC.Utility.SD;
using System.Net.Mime;

namespace MVC.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
