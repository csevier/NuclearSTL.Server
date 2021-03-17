using System;
using Npgsql;

namespace nuclear_server.Repositories
{
    public class GeostampRepository
    {
        public bool InsertGeostamp(Geostamp stamp)
        {
            string cs = "Host=localhost;Username=postgres;Password=<your_pass>#;Database=nuclear_stl"; // yes yes no cnnection string passwords, truth.
            using NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();
            string sql = $"INSERT INTO readings (geometry, lat, lon, timestamp) VALUES (ST_SetSRID(ST_MakePoint({stamp.Lon},{stamp.Lat}),4326), {stamp.Lat},{stamp.Lon},'{stamp.TimeStamp}');";
            try
            {
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}