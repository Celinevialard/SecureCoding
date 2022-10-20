using Microsoft.Data.SqlClient;

namespace AirplaneNotSecure.Database;

public class UserDb : IUserDb
{
    private string ConnectionString { get; }
    public UserDb()
    {
        ConnectionString = "Data Source=153.109.124.35;Initial Catalog=SecureCodingJulienneCelineTheo;Encrypt=false;User ID=6231db;Password=Pwd46231.";
    }

    public User GetUser(string login)
    {
        User results = null;

        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT * FROM [User] 
							WHERE Login = @login";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@login", login);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        results = ReadUser(dr);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return results;
    }

    public User GetUser(int id)
    {
        User results = null;

        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT * FROM [User] 
							WHERE IdUser = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        results = ReadUser(dr);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return results;
    }

    public bool UpdateUser(User user)
    {

        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string query = @"UPDATE [User] SET Password = '" + user.Password+@"',FirstName = '"+user.Firstname+@"',Lastname = '"+user.Lastname+@"'WHERE IdUser = "+user.Id+@"";
                
                SqlCommand cmd = new SqlCommand(query, cn);

                cn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private User ReadUser(SqlDataReader dr)
    {
        User user = new User();

        user.Id = (int)dr["IdUser"];
        user.Lastname = (string)dr["Lastname"];
        user.Firstname = (string)dr["Firstname"];
        user.Login = (string)dr["Login"];
        user.Password = (string)dr["Password"];

        return user;
    }
}
