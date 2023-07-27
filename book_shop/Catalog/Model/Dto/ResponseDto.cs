namespace Catalog.Host.Model.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = true;
        public string Messenge { get; set; } = "";
    }
}
