using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace core_ewidencja.Models
{
    public class AppDataBase:IDisposable
    {

        public MySqlConnection Connection { get; }

        public AppDataBase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();


    }
}
