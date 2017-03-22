using SimpleHttpServer;
using SimpleMVC;

namespace SoftUniStore
{
    class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore");
        }
    }
}
