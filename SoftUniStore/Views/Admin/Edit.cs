using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Admin
{
    public class Edit : IRenderable<GameEditViewModel>
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

        public GameEditViewModel Model { get; set; }
    }
}
