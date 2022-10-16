namespace AirplaneSecure.Database
{
    public interface IUserDb
    {
        User GetUser(int id);
        User GetUser(string login);
        bool UpdateUser(User user);
    }
}