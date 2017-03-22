using System;
using SoftUniStore.Utilities;

namespace SoftUniStore.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public override string ToString()
        {
            string htmlDetails = WebUtil.RetrieveFileContent(Constants.GameDetails);

            string result = string.Format(htmlDetails, this.Title, this.Trailer, 
                this.Description, this.Price, this.Size, this.ReleaseDate, this.Id);

            return result;
        }
    }
}
