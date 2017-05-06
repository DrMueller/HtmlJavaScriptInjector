using System;
using System.IO;
using System.Reflection;
using Mmu.Hji.Console.Services;

namespace Mmu.Hji.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = args[0];
            var htmlFileService = new HtmlFileService(basePath);
            var jsFileService = new JavaScriptFileService(basePath);

            var javaScript = jsFileService.LoadJavaScriptFromFiles();

            htmlFileService.RemoveJavaScriptReferencesFromAngularCli();
            htmlFileService.AddJavaScriptBeforeBodyClosingTag(javaScript);
            jsFileService.DeleteJavaScriptFiles();
        }
    }
}