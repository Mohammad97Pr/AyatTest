using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AyatGroupTest.Authorization.Roles;
using AyatGroupTest.Authorization.Users;
using AyatGroupTest.MultiTenancy;
using AyatGroupTest.Conversations;
using AyatGroupTest.Messages;

namespace AyatGroupTest.EntityFrameworkCore
{
    public class AyatGroupTestDbContext : AbpZeroDbContext<Tenant, Role, User, AyatGroupTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public AyatGroupTestDbContext(DbContextOptions<AyatGroupTestDbContext> options)
            : base(options)
        {
        }
    }
}
