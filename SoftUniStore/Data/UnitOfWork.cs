using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoftUniStoreContext context = new SoftUniStoreContext();

        private IRepository<User> users;
        private IRepository<Session> sessions;
        private IRepository<Game> games;

        public IRepository<User> Users => users 
            ?? (this.users = new Repository<User>(this.context.Set<User>()));

        public IRepository<Session> Sessions => sessions 
            ?? (this.sessions = new Repository<Session>(this.context.Set<Session>()));

        public IRepository<Game> Games => games 
            ?? (this.games = new Repository<Game>(this.context.Set<Game>()));

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
