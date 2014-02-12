using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HelloHelios
{
    public class Startup
    {
        // osFamily="4" required in *.csfg for .net 4.5.1 for azure cloud service
        //
        // No need for Microsoft.Owin.Hosting.SystemWeb this is the adapter for OWIN to plug in with System.Web
        //
        // Self hosting and HttpListener Owin packages are for self hosting solutions, see the CrowdSourcing project for an example of this.
        //
        // Microsoft.Owin.Hosting.IIS is the Helios hosting on top of IIS but without System.Web. The Microsoft.AspNet.Loader.IIS is essentially a swtich that sends requests to Helios
        // not the traditional System.Web asp.net pipeline.
        //
        public void Configuration(IAppBuilder app)
        {
            //app.Use((ctx, continuation) =>
            //{
            //    ((Action)ctx.Environment["server.DisableResponseBuffering"])();
            //    return continuation();
            //});

            // In the immediate window use AppDomain.CurrentDomain.GetAssemblies() to make sure System.Web not loaded 
            //app.UseErrorPage(new ErrorPageOptions() { ShowExceptionDetails = true, ShowHeaders = true, ShowSourceCode = true, ShowEnvironment = true, ShowCookies = true });

            //app.UseFileServer(new FileServerOptions()
            //{
            //    RequestPath = PathString.Empty,
            //    FileSystem = new PhysicalFileSystem(@".\DefaultDocument"),
            //});

            app.UseStaticFiles("/app");
            app.UseStaticFiles("/Scripts");
            app.UseStaticFiles("/Content");
            app.UseStaticFiles("/fonts");

            // Web API routes
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            app.UseWebApi(config);

            app.Run(async (context) =>  // IOWinContext
            {
                // TODO also ignore the fav.ico request

                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html";

                await context.Response.SendFileAsync("./app/Index.html");

                //string header = "<html><body><h1>Hello Helios!</h1>";
                //await context.Response.WriteAsync(header);

                //await context.Response.WriteAsync("</body></html>");
                return;
            });
        }
    }
}