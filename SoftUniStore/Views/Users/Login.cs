using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.Utilities;

namespace SoftUniStore.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(WebUtil.RetrieveFileContent(Constants.Header));
            html.Append(WebUtil.RetrieveFileContent(Constants.NavigationNotLogged));
            html.Append(WebUtil.RetrieveFileContent(Constants.Login));
            html.Append(WebUtil.RetrieveFileContent(Constants.Footer));

            return html.ToString();
        }
    }
}
