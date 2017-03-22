using System.Collections.Generic;
using System.Linq;
using SimpleHttpServer.Models;
using SoftUniStore.BindingModels;
using SoftUniStore.Data;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class UsersServices : Service
    {
        public UsersServices(UnitOfWork data) : base(data)
        {
        }

        public bool VerifyUserRegister(RegisterUserBindingModel bm)
        {
            if (!bm.Email.Contains('.') || !bm.Email.Contains('@')
                || this.data.Users.GetAll().Any(u => u.Email == bm.Email))
            {
                return false;
            }
            if (bm.Password.Length < 6 || !bm.Password.Any(char.IsUpper)
                || !bm.Password.Any(char.IsLower) || !bm.Password.Any(char.IsDigit))
            {
                return false;
            }
            if (bm.Password != bm.ConfirmPassword)
            {
                return false;
            }
            if (string.IsNullOrEmpty(bm.Fullname))
            {
                return false;
            }

            return true;
        }

        public void RegisterUser(RegisterUserBindingModel bm)
        {
            User user = new User
            {
                Email = bm.Email,
                Password = bm.Password,
                FullName = bm.Fullname
            };
            if (this.data.Users.GetAll().Any())
            {
                user.IsAdmin = false;
            }
            else
            {
                user.IsAdmin = true;
            }

            this.data.Users.Add(user);
            this.data.Save();
        }

        public void LoginUser(HttpSession session, LoginUserBindingModel bm)
        {
            User user =
                this.data.Users.SingleOrDefault(
                    u => u.Email == bm.Email && u.Password == bm.Password);
            if (user != null)
            {
                Session sessionToAdd = new Session
                {
                    SessionId = session.Id,
                    IsActive = true,
                    User = user
                };
                this.data.Sessions.Add(sessionToAdd);
                this.data.Save();
            }
        }
    }
}
