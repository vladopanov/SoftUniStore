using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.Utilities;

namespace SoftUniStore.Views.Admin
{
    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(WebUtil.RetrieveFileContent(Constants.Header));
            html.Append(WebUtil.RetrieveFileContent(Constants.NavigationLogged));
            html.Append(WebUtil.RetrieveFileContent(Constants.AddGame));
            html.Append(WebUtil.RetrieveFileContent(Constants.Footer));

            return html.ToString();
        }
    }
}
