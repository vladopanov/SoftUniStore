using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Games
{
    public class Details : IRenderable<GameDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(WebUtil.RetrieveFileContent(Constants.Header));
            html.Append(WebUtil.RetrieveFileContent(Constants.NavigationLogged));

            html.Append(Model);

            html.Append(WebUtil.RetrieveFileContent(Constants.Footer));

            return html.ToString();
        }

        public GameDetailsViewModel Model { get; set; }
    }
}
