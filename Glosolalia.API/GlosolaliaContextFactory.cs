//using Glosolalia.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace Glosolalia.API
//{
//    public class GlosolaliaContextFactory : IDesignTimeDbContextFactory<GlosolaliaContext>
//    {
//        private const string AdminConnectionString = "GLOSOLALIA_ADMIN_CONNECTION_STRING";
//        public GlosolaliaContext CreateDbContext(string[] args)
//        {
//            var connectionString = Environment.GetEnvironmentVariable(AdminConnectionString);
//            if (string.IsNullOrEmpty(connectionString))
//            {

//                throw new ApplicationException(
//                    $"Please set the environment variable {AdminConnectionString}");
//            }
//            var options = new DbContextOptionsBuilder<GlosolaliaContext>()
//                .UseSqlServer(connectionString, sqlOptions =>
//                {
//                    sqlOptions.MigrationsAssembly(typeof(GlosolaliaContext).Assembly.FullName);
//                }).Options;
//            return new GlosolaliaContext(options);

//        }
//    }
//}
