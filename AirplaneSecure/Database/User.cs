namespace AirplaneSecure.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get;set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Salt { get; set; }
    }
}