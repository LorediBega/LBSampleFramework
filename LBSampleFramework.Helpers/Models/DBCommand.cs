using System;
using System.Data.SqlClient;

namespace LBSampleFramework.Helpers
{
    public class DBCommand
    {
        public SqlConnection Connection;
        public SqlCommand Command;
        public SqlDataReader Reader;

    }
}
