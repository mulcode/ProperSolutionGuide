using Npgsql;

namespace PSG.DataAccessLayer
{
    public class AppAdoBase
    {
        public string connectionString = "Server=localhost;Port=5432;Database=ado_crud;Username=postgres;Password=root";

        //For holding connection Object throughout the class
        internal NpgsqlConnection? Connection;
        public NpgsqlConnection OpenConnection()
        {
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open(); //open connection
            return Connection;
        }
        public int ExecuteSql(string sql)
        {
            //open connection and hold in the property
            OpenConnection();

            NpgsqlCommand command = new NpgsqlCommand();

            //Feed sql to the command
            command.CommandText = sql;
            //Feed connection to the command 
            command.Connection = Connection;

            //Reading Entities unit count
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }
    }
}