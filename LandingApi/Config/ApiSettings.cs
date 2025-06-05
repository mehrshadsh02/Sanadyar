namespace LandingApi.Config
{
    public class ApiSettings
    {
        public string Version { get; set; }
        public Endpoint Endpoint { get; set; }
    }

    public class Endpoint
    {
        public HttpEndpoint Http { get; set; }
    }

    public class HttpEndpoint
    {
        public string Url { get; set; }
    }
}
