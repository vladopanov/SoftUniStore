using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftUniStore.BindingModels;
using SoftUniStore.Data;
using SoftUniStore.Security;
using SoftUniStore.Services;

namespace SoftUniStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly UnitOfWork data;
        private readonly SignInManager signInManager;
        private readonly UsersServices service;

        public UsersController() : this(new UnitOfWork())
        {
        }

        public UsersController(UnitOfWork unitOfWork)
        {
            this.data = unitOfWork;
            this.signInManager = new SignInManager(this.data);
            this.service = new UsersServices(this.data);
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel bindingModel)
        {
            if (!service.VerifyUserRegister(bindingModel))
            {
                return this.View();
            }
            service.RegisterUser(bindingModel);

            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel bindingModel)
        {
            service.LoginUser(session, bindingModel);
            if (!this.signInManager.IsAuthenticated(session))
            {
                return this.View();
            }
            Redirect(response, "/games/all");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            signInManager.Logout(response, session.Id);
            Redirect(response, "/users/login");
            return null;
        }
    }
}
