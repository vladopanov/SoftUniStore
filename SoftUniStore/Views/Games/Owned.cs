using System.Collections.Generic;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Games
{
    public class Owned : IRenderable<IEnumerable<GameViewModel>>
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(WebUtil.RetrieveFileContent(Constants.Header));
            html.Append(WebUtil.RetrieveFileContent(Constants.NavigationLogged));
            html.Append(WebUtil.RetrieveFileContent(Constants.HomeTop));

            int counter = 0;
            foreach (var game in Model)
            {
                if (counter % 3 == 0)
                {
                    html.Append(@"</div>
                <div class=""card-group"">");
                }

                html.Append(game);
                counter++;
            }

            html.Append(WebUtil.RetrieveFileContent(Constants.HomeBottom));
            html.Append(WebUtil.RetrieveFileContent(Constants.Footer));

            return html.ToString();
        }

        public IEnumerable<GameViewModel> Model { get; set; }
    }
}
