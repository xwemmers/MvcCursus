using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCursus.MiddleWare
{
    public static class ExtensionMethods
    {
        // Een extension method moet voldoen aan de volgende voorwaarden:

        // 1. De method moet static zijn
        // 2. De method wordt toegekend aan de eerste parameter van de functie. 
        // 3. Die parameter krijgt het keyword 'this'
        // 4. De functie en de class moeten static zijn
        
        // Voor MVC Core moet het volgende:
        // 1. return IApplicationBuilder
        // 2. Vertel MVC dat hij in de folder Node_Modules moet kijken

        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;

            app.UseStaticFiles(options);

            return app;
        }
    }
}
