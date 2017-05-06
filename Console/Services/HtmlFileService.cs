using System;
using System.IO;

namespace Mmu.Hji.Console.Services
{
    public class HtmlFileService
    {
        private const string FILE_NAME = "index.html";
        private readonly string _filePath;

        public HtmlFileService(string path)
        {
            _filePath = Path.Combine(path, FILE_NAME);
        }

        public void AddJavaScriptBeforeBodyClosingTag(string javaScript)
        {
            var htmlText = File.ReadAllText(_filePath);

            javaScript = "<script>" + javaScript + "</script>";

            var indexClosingBody = htmlText.IndexOf("</body>", StringComparison.CurrentCultureIgnoreCase);
            var newText = htmlText.Insert(indexClosingBody, javaScript);

            File.WriteAllText(_filePath, newText);
        }

        public void RemoveJavaScriptReferencesFromAngularCli()
        {
            var htmlText = File.ReadAllText(_filePath);

            var startIndexScript = htmlText.IndexOf("<script", htmlText.IndexOf("<body>", StringComparison.OrdinalIgnoreCase), StringComparison.OrdinalIgnoreCase);
            var indexClosingBody = htmlText.IndexOf("</body>", StringComparison.CurrentCultureIgnoreCase);

            var newText = htmlText.Substring(0, startIndexScript);
            newText += htmlText.Substring(indexClosingBody);

            File.WriteAllText(_filePath, newText);
        }
    }
}