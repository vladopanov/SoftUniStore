using System;
using SoftUniStore.Utilities;

namespace SoftUniStore.ViewModels
{
    public class GameEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public string Trailer { get; set; }

        public override string ToString()
        {
            string htmlEdit = WebUtil.RetrieveFileContent(Constants.EditGame);

            string result = string.Format(htmlEdit, this.Id, this.Title, this.Description,
                this.Thumbnail, this.Price, this.Size, this.Trailer);

            return result;
        }
    }
}
