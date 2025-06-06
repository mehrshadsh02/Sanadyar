namespace LandingApi.Config
{
    public class SiteSettings
    {
        //public bool Careplan { get; set; }
        //public bool Tracing { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DataSource { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }
        public bool MultipleActiveResultSets { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
