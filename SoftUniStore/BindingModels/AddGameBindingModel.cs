using System;

namespace SoftUniStore.BindingModels
{
    public class AddGameBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public string Trailer { get; set; }

        public DateTime Releasedate { get; set; }
    }
}
