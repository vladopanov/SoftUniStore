using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.BindingModels;
using SoftUniStore.Data;
using SoftUniStore.Security;
using SoftUniStore.Services;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly UnitOfWork data;
        private readonly SignInManager signInManager;
        private readonly AdminServices service;

        public AdminController() : this(new UnitOfWork())
        {
        }

        public AdminController(UnitOfWork unitOfWork)
        {
            this.data = unitOfWork;
            this.signInManager = new SignInManager(this.data);
            this.service = new AdminServices(this.data);
        }

        [HttpGet]
        public IActionResult<IEnumerable<AdminGamesViewModel>> Games(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            IEnumerable<AdminGamesViewModel> games = this.service.GetAdminGames();

            return this.View(games);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpSession session, HttpResponse response, AddGameBindingModel bm)
        {
            if (!this.service.VerifyAddGame(bm))
            {
                return this.View();
            }
            this.service.AddGame(bm);

            Redirect(response, "/admin/games");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(HttpSession session, HttpResponse response, int id)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            this.service.DeleteGame(id);

            Redirect(response, "/admin/games");
            return null;
        }

        [HttpGet]
        public IActionResult<GameEditViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            GameEditViewModel game = this.service.GetEditGame(id);

            return this.View(game);
        }

        [HttpPost]
        public IActionResult<GameEditViewModel> Edit(HttpSession session, HttpResponse response, EditGameBindingModel bm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.signInManager.IsAdmin(session))
            {
                Redirect(response, "/games/all");
                return null;
            }

            this.service.EditGame(bm);

            Redirect(response, "/admin/games");
            return null;
        }
    }
}
