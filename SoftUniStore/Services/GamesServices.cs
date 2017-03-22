using System.Collections.Generic;
using System.Linq;
using SoftUniStore.Data;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class GamesServices : Service
    {
        public GamesServices(UnitOfWork data) : base(data)
        {
        }


        public IEnumerable<GameViewModel> GetAllGames()
        {
            IEnumerable<GameViewModel> games = this.data.Games.GetAll()
                .Select(game => new GameViewModel()
            {
                    Id = game.Id,
                    Thumbnail = game.ImageThumbnail,
                    Title = game.Title,
                    Price = game.Price,
                    Size = game.Size,
                    Description = game.Description
            });

            return games;
        }

        public IEnumerable<GameViewModel> GetOwnedGames(User user)
        {
            IEnumerable<GameViewModel> games = this.data.Users.GetById(user.Id).Games
                .Select(game => new GameViewModel()
                {
                    Id = game.Id,
                    Thumbnail = game.ImageThumbnail,
                    Title = game.Title,
                    Price = game.Price,
                    Size = game.Size,
                    Description = game.Description
                });

            return games;
        }

        public GameDetailsViewModel GetGameDetails(int id)
        {
            Game game = this.data.Games.GetById(id);
            GameDetailsViewModel viewModel = new GameDetailsViewModel()
            {
                Id = game.Id,
                Description = game.Description,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Title = game.Title,
                Trailer = game.Trailer
            };

            return viewModel;
        }

        public void BuyGame(int bmGameId, User user)
        {
            Game gameToBuy = this.data.Games.GetById(bmGameId);
            User buyingUser = this.data.Users.GetById(user.Id);

            if (!buyingUser.Games.Contains(gameToBuy))
            {
                buyingUser.Games.Add(gameToBuy);
                this.data.Save();
            }
        }
    }
}
