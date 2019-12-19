using System;
using System.Data.SqlClient;

namespace ConnectionLibrary
{
    public class SqlDBConnect: IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=My-PC\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
        }
    }
}
