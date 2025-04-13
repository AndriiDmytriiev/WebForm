using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HtmlAgilityPack;
using Microsoft.Web.Helpers;

namespace WebForm1
{
    public partial class _Default : Page
    {
        private static readonly Dictionary<string, string> wikiLinks = new()
        {
            { "Mercury", "https://en.wikipedia.org/wiki/Mercury_(planet)" },
            { "Venus", "https://en.wikipedia.org/wiki/Venus" },
            { "Earth", "https://en.wikipedia.org/wiki/Earth" },
            { "Moon", "https://en.wikipedia.org/wiki/Moon" },
            { "Mars", "https://en.wikipedia.org/wiki/Mars" }
        };

        private static readonly Dictionary<string, string> videoLinks = new()
        {
            { "Mercury", "https://www.youtube.com/embed/B588JHKSlEE" },
            { "Venus", "https://www.youtube.com/embed/djP-IdHFQWU" },
            { "Earth", "https://www.youtube.com/embed/KJwYBJMSbPI" },
            { "Moon", "https://www.youtube.com/embed/kS4VBhQGU9A" },
            { "Mars", "https://www.youtube.com/embed/D8pnmwOXhoY" }
        };

        private static readonly Dictionary<string, string> imageLinks = new()
        {
            { "Mercury", "https://vip-fargo.com/images/Mercury.jpg" },
            { "Venus", "https://vip-fargo.com/images/venus.jpg" },
            { "Earth", "https://vip-fargo.com/images/earth.jpg" },
            { "Moon", "https://vip-fargo.com/images/moon.jpg" },
            { "Mars", "https://vip-fargo.com/images/mars.jpeg" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPageContent("Mercury", "1.txt");
            }
        }

        protected async void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            string selected = e.Item.Value;

            if (wikiLinks.ContainsKey(selected))
            {
                string summary = await GetWikipediaSummaryAsync(wikiLinks[selected]);
                TextBox1.Text = summary;
                webFrame.Attributes["src"] = wikiLinks[selected];
            }
            else
            {
                TextBox1.Text = "No information available.";
                webFrame.Attributes["src"] = "";
            }

            if (videoLinks.TryGetValue(selected, out var videoUrl))
            {
                webFrame1.Src = videoUrl;
            }

            if (imageLinks.TryGetValue(selected, out var imgUrl))
            {
                imgDisplay.ImageUrl = imgUrl;
            }

            string textFilePath = Server.MapPath($"~/App_Data/{GetFileIndex(selected)}.txt");
            if (File.Exists(textFilePath))
            {
                TextBox1.Text += "\n\n" + File.ReadAllText(textFilePath);
            }
        }

        private static string GetFileIndex(string key) =>
            key switch
            {
                "Mercury" => "1",
                "Venus" => "2",
                "Earth" => "3",
                "Moon" => "4",
                "Mars" => "5",
                _ => "0"
            };

        private async Task<string> GetWikipediaSummaryAsync(string url)
        {
            using HttpClient client = new();
            string html = await client.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var summaryNode = doc.DocumentNode.SelectSingleNode("//p[normalize-space(string()) != '']");
            return summaryNode != null
                ? HtmlEntity.DeEntitize(summaryNode.InnerText.Trim())
                : "Summary not found.";
        }

        private void LoadPageContent(string planet, string fileName)
        {
            webFrame.Attributes["src"] = wikiLinks[planet];
            string filePath = Server.MapPath($"~/App_Data/{fileName}");

            TextBox1.Text = File.Exists(filePath)
                ? File.ReadAllText(filePath)
                : "File not found.";

            imgDisplay.ImageUrl = imageLinks[planet];
            webFrame1.Src = videoLinks[planet];
        }
    }
}
