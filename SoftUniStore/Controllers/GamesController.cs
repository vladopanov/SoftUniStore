using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.BindingModels;
using SoftUniStore.Data;
using SoftUniStore.Models;
using SoftUniStore.Security;
using SoftUniStore.Services;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly UnitOfWork data;
        private readonly SignInManager signInManager;
        private readonly GamesServices service;

        public GamesController() : this(new UnitOfWork())
        {
        }

        public GamesController(UnitOfWork unitOfWork)
        {
            this.data = unitOfWork;
            this.signInManager = new SignInManager(this.data);
            this.service = new GamesServices(this.data);
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> All(HttpResponse response, HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            IEnumerable<GameViewModel> games = this.service.GetAllGames();

            return this.View(games);
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> Owned(HttpResponse response, HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User user = this.signInManager.GetCurrentUser(session);
            IEnumerable<GameViewModel> games = this.service.GetOwnedGames(user);

            return this.View(games);
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(HttpResponse response, HttpSession session, int gameId)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            GameDetailsViewModel gameDetails = this.service.GetGameDetails(gameId);

            return this.View(gameDetails);
        }

        [HttpPost]
        public IActionResult Details(HttpResponse response, HttpSession session,
            BuyGameBindingModel bm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User user = this.signInManager.GetCurrentUser(session);
            this.service.BuyGame(bm.GameId, user);

            Redirect(response, "/games/owned");
            return null;
        }
    }
}
