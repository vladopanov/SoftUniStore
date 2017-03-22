using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    using System.Data.Entity;

    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("name=SoftUniStoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Game> Games { get; set; }
    }
}