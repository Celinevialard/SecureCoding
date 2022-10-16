using Microsoft.Data.SqlClient;

namespace AirplaneSecure.Database;

public class UserDb : IUserDb
{
    private IConfiguration Configuration { get; }
    public UserDb(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public User GetUser(string login)
    {
        User results = null;
        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        try
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM User 
							WHERE login = @login";
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
        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        try
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM User 
							WHERE id = @id";
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
        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        try
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE User
                            SET password = @password,
                            name = @name,
                            lastname = @lastname
							WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
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

        user.Id = (int)dr["id"];
        user.Name = (string)dr["name"];

        return user;
    }
}
