namespace AirplaneNotSecure.Utils
{
    public static class Helper
    {
        public static int GetUserId(this ISession session)
        {
            if (session.GetString("User") == null)
            {
                return 0;
            }
           return int.Parse(session.GetString("User"));
        }
    }
}
