namespace AlbumWeb.Models
{    
    public class EndpointOptions
    {
        public ApiEndpoint[] ApiEndpoints { get; set; } = Array.Empty<ApiEndpoint>();
    }

    public class ApiEndpoint
    {
        public string Name { get; set; }
        public string Url { get; set; }        
    }
}
