using System.IO;
using System.Linq;
using System.Text;

namespace Mmu.Hji.Console.Services
{
    internal class JavaScriptFileService
    {
        private static readonly string[] _jsFiles =
        {
            //"inline.bundle.js",
            //"polyfills.bundle.js",
            //"styles.bundle.js",
            //"vendor.bundle.js",
            //"main.bundle.js"
        };
        private readonly string[] _jsFilePaths;

        public JavaScriptFileService(string basePath)
        {
            _jsFilePaths = _jsFiles.Select(
                f =>
                {
                    var combinedPath = Path.Combine(basePath, f);
                    return combinedPath;
                }).ToArray();
        }

        public void DeleteJavaScriptFiles()
        {
            foreach (var js in _jsFilePaths)
            {
                File.Delete(js);
            }
        }

        public string LoadJavaScriptFromFiles()
        {
            var sb = new StringBuilder();

            foreach (var js in _jsFilePaths)
            {
                var jsText = File.ReadAllText(js);
                sb.Append(jsText);
            }

            var result = sb.ToString();
            return result;
        }
    }
}