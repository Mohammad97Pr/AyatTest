using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AyatGroupTest.EntityFrameworkCore
{
    public static class AyatGroupTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AyatGroupTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AyatGroupTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
