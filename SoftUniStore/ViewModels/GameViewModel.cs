namespace SoftUniStore.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Thumbnail { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            if (this.Description.Length > 300)
            {
                this.Description = this.Description.Substring(0, 300);
            }

            string gameHtml = $@"<div class=""card col-4 thumbnail"">

                        <img class=""card-image-top img-fluid img-thumbnail"" src=""{this.Thumbnail}"">

                        <div class=""card-block"">
                            <h4 class=""card-title"">{this.Title}</h4>
                            <p class=""card-text""><strong>Price</strong> - {this.Price}&euro;</p>
                            <p class=""card-text""><strong>Size</strong> - {this.Size} GB</p>
                            <p class=""card-text"">{this.Description}</p>
                        </div>

                        <div class=""card-footer"">
                            <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/games/details/?gameId={this.Id}"">Info</a>
                        </div>

                    </div>";

            return gameHtml;
        }
    }
}
