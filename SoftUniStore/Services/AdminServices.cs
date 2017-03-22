using System.Collections.Generic;
using System.Linq;
using SoftUniStore.BindingModels;
using SoftUniStore.Data;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class AdminServices : Service
    {
        public AdminServices(UnitOfWork data) : base(data)
        {
        }

        public IEnumerable<AdminGamesViewModel> GetAdminGames()
        {
            IEnumerable<AdminGamesViewModel> games = this.data.Games.GetAll()
                .Select(game => new AdminGamesViewModel()
                {
                    Id = game.Id,
                    Name = game.Title,
                    Size = game.Size,
                    Price = game.Price
                });

            return games;
        }

        public bool VerifyAddGame(AddGameBindingModel bm)
        {
            if (!char.IsUpper(bm.Title[0]) || bm.Title.Length < 3 || bm.Title.Length > 100)
            {
                return false;
            }
            if (bm.Price < 0 || bm.Size < 0)
            {
                return false;
            }

            string trailerId = bm.Trailer.Substring(bm.Trailer.Length - 11);
            if (trailerId.Length != 11)
            {
                return false;
            }
            if (!bm.Thumbnail.StartsWith("http://") && !bm.Thumbnail.StartsWith("https://"))
            {
                return false; ;
            }
            if (bm.Description.Length < 20)
            {
                return false;
            }

            return true;
        }

        public void AddGame(AddGameBindingModel bm)
        {
            Game game = new Game()
            {
                Description = bm.Description,
                ImageThumbnail = bm.Thumbnail,
                Price = bm.Price,
                ReleaseDate = bm.Releasedate,
                Size = bm.Size,
                Title = bm.Title,
                Trailer = bm.Trailer.Substring(bm.Trailer.Length - 11)
            };

            this.data.Games.Add(game);
            this.data.Save();
        }

        public void DeleteGame(int id)
        {
            Game game = this.data.Games.GetById(id);
            this.data.Games.Delete(game);
            this.data.Save();
        }

        public GameEditViewModel GetEditGame(int id)
        {
            var game = this.data.Games.GetById(id);

            GameEditViewModel vm = new GameEditViewModel()
            {
                Title = game.Title,
                Description = game.Description,
                Id = game.Id,
                Price = game.Price,
                Size = game.Size,
                Thumbnail = game.ImageThumbnail,
                Trailer = game.Trailer
            };

            return vm;
        }

        public void EditGame(EditGameBindingModel bm)
        {
            Game game = this.data.Games.GetById(bm.Id);
            game.Size = bm.Size;
            game.Description = bm.Description;
            game.ImageThumbnail = "https://www.youtube.com/watch?v=" + bm.Thumbnail;
            game.Price = bm.Price;
            game.Title = bm.Title;
            game.Trailer = bm.Trailer;

            this.data.Save();
        }
    }
}
