using System;
namespace Template.Data
{
    public class Context
    {
        public string ConnectionString { get; }

        public Context(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
