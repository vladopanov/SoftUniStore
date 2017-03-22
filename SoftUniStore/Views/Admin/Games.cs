using System.Collections.Generic;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Admin
{
    public class Games : IRenderable<IEnumerable<AdminGamesViewModel>>
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(WebUtil.RetrieveFileContent(Constants.Header));
            html.Append(WebUtil.RetrieveFileContent(Constants.NavigationLogged));
            html.Append(WebUtil.RetrieveFileContent(Constants.AdminGamesTop));

            foreach (var game in Model)
            {
                html.Append(game);
            }

            html.Append(WebUtil.RetrieveFileContent(Constants.AdminGamesBottom));
            html.Append(WebUtil.RetrieveFileContent(Constants.Footer));

            return html.ToString();
        }

        public IEnumerable<AdminGamesViewModel> Model { get; set; }
    }
}
