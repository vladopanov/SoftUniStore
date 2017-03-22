using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.Data;
using SoftUniStore.Models;

namespace SoftUniStore.Security
{
    public class SignInManager
    {
        private readonly UnitOfWork unitOfWork;

        public SignInManager(UnitOfWork dbContext)
        {
            this.unitOfWork = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.unitOfWork.Sessions.FindAll(s => s.SessionId == session.Id && s.IsActive).Any();

            return isAuthenticated;
        }

        public bool IsAdmin(HttpSession session)
        {
            bool isAdmin = this.unitOfWork.Sessions.SingleOrDefault(s => s.SessionId == session.Id).User.IsAdmin;

            return isAdmin;
        }

        public User GetCurrentUser(HttpSession session)
        {
            User user = this.unitOfWork.Sessions.SingleOrDefault(s => s.SessionId == session.Id).User;
            return user;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session sessionEntity = this.unitOfWork.Sessions.FindAll(s => s.SessionId == sessionId).FirstOrDefault();
            if (sessionEntity != null) sessionEntity.IsActive = false;
            this.unitOfWork.Save();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
