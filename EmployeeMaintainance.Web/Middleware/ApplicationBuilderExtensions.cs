using Microsoft.Extensions.FileProviders;
using System.IO;

//To make the below method discoverable
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(
            this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions {RequestPath = "/node_modules", FileProvider = fileProvider}; 
            app.UseStaticFiles(options);
            //Return instance of IApplicationBuilder
            return app;
        }
    }
}
 