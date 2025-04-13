//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Windows.Forms;
//using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Grpc.Core;
using HtmlAgilityPack;
using Microsoft.Web.Helpers;
using FileUpload = Microsoft.Web.Helpers.FileUpload;
namespace WebForm1
{
    public partial class _Default : Page
    {
        private static readonly Dictionary<string, string> wikiLinks = new Dictionary<string, string>
        {
            { "Mercury", "https://en.wikipedia.org/wiki/Mercury_(planet)" },
            { "Venus", "https://en.wikipedia.org/wiki/Venus" },
            { "Earth", "https://en.wikipedia.org/wiki/Earth" },
            { "Moon", "https://en.wikipedia.org/wiki/Moon" },
            { "Mars", "https://en.wikipedia.org/wiki/Mars" },
            { "Phobos", "https://en.wikipedia.org/wiki/Phobos" },
            { "Deimos", "https://en.wikipedia.org/wiki/Deimos_(moon)" },
            { "Jupiter", "https://en.wikipedia.org/wiki/Jupiter" },
            { "Io", "https://en.wikipedia.org/wiki/Io_(moon)" },
            { "Europa", "https://en.wikipedia.org/wiki/Europa_(moon)" },
            { "Ganymede", "https://en.wikipedia.org/wiki/Ganymede_(moon)" },
            { "Callisto", "https://en.wikipedia.org/wiki/Callisto_(moon)" },
            { "Saturn", "https://en.wikipedia.org/wiki/Saturn" },
            { "Titan", "https://en.wikipedia.org/wiki/Titan_(moon)" },
            { "Enceladus", "https://en.wikipedia.org/wiki/Enceladus" },
            { "Rhea", "https://en.wikipedia.org/wiki/Rhea_(moon)" },
            { "Mimas", "https://en.wikipedia.org/wiki/Mimas" },
            { "Iapetus", "https://en.wikipedia.org/wiki/Iapetus_(moon)" },
            { "Uranus", "https://en.wikipedia.org/wiki/Uranus" },
            { "Titania", "https://en.wikipedia.org/wiki/Titania_(moon)" },
            { "Oberon", "https://en.wikipedia.org/wiki/Oberon_(moon)" },
            { "Ariel", "https://en.wikipedia.org/wiki/Ariel_(moon)" },
            { "Umbriel", "https://en.wikipedia.org/wiki/Umbriel" },
            { "Miranda", "https://en.wikipedia.org/wiki/Miranda_(moon)" },
            { "Neptune", "https://en.wikipedia.org/wiki/Neptune" },
              { "Triton", "https://en.wikipedia.org/wiki/Triton_(moon)" },
              { "Nereid", "https://en.wikipedia.org/wiki/Nereid_(moon)" },
              { "Pluto", "https://en.wikipedia.org/wiki/Pluto" },
              { "Charon", "https://en.wikipedia.org/wiki/Charon" },
              { "Nix", "https://en.wikipedia.org/wiki/Nix_(moon)" },
              { "Hydra", "https://en.wikipedia.org/wiki/Hydra_(moon)" },
              { "Kerberos", "https://en.wikipedia.org/wiki/Kerberos_(moon)" },
              { "Styx", "https://en.wikipedia.org/wiki/Styx_(moon)" }




        };
        protected void Page_Load(object sender, EventArgs e)
        {
            string targetUrl = "https://en.wikipedia.org/wiki/Mercury_(planet)";
            webFrame.Attributes["src"] = targetUrl;
            string filePath = Server.MapPath("~/App_Data/1.txt");

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                TextBox1.Text = content;
            }
            else
            {
                TextBox1.Text = "File not found.";
            }


            // Set the ImageUrl to the uploaded file path
            imgDisplay.ImageUrl = "https://vip-fargo.com/images/Mercury.jpg";
            string videoUrl = "https://www.youtube.com/embed/AWk9k0a1oU4";  // Replace 'xyz123' with the actual video ID

            webFrame1.Src = videoUrl;
        }
        protected async void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            string selected = e.Item.Value;

            // Map of YouTube video URLs based on selection
            Dictionary<string, string> videoMap = new Dictionary<string, string>()
    {
        { "Mercury", "https://www.youtube.com/embed/B588JHKSlEE" },
        { "Venus", "https://www.youtube.com/embed/djP-IdHFQWU" },
        { "Earth", "https://www.youtube.com/embed/KJwYBJMSbPI" },
        { "Moon", "https://www.youtube.com/embed/kS4VBhQGU9A" },
        { "Mars", "https://www.youtube.com/embed/D8pnmwOXhoY" },
        { "Phobos", "https://www.youtube.com/embed/N5VteF4pE6I" },
        { "Deimos", "https://www.youtube.com/embed/L1bOU9ZgY4g" },
        { "Jupiter", "https://www.youtube.com/embed/OT8Lkr1f_2k" },
        { "Io", "https://www.youtube.com/embed/T5W9FM7hBFA" },
        { "Europa", "https://www.youtube.com/embed/HZVkrwiRARE" },
        { "Ganymede", "https://www.youtube.com/embed/yPGshOZJK9Q" },
        { "Callisto", "https://www.youtube.com/embed/kGV18NaIWhs" },
        { "Saturn", "https://www.youtube.com/embed/f5VZVGrDWTQ" },
        { "Titan", "https://www.youtube.com/embed/WtsurAokqVo" },
        { "Enceladus", "https://www.youtube.com/embed/pUAn7aqkRdk" },
        { "Rhea", "https://www.youtube.com/embed/CmHvLbBly5k" },
        { "Mimas", "https://www.youtube.com/embed/v8d6z0rFNL8" },
        { "Iapetus", "https://www.youtube.com/embed/5RvEbZzYwtE" },
        { "Uranus", "https://www.youtube.com/embed/DL-L1fZf2ZQ" },
        { "Titania", "https://www.youtube.com/embed/T6OeQlN-jo4" },
        { "Oberon", "https://www.youtube.com/embed/taFxMd-8bBg" },
        { "Ariel", "https://www.youtube.com/embed/YrQx7oYXBuw" },
        { "Umbriel", "https://www.youtube.com/embed/yIkhtm1kR9s" },
        { "Miranda", "https://www.youtube.com/embed/W_EaMKPOFNo" },
        { "Neptune", "https://www.youtube.com/embed/jFBZzWAzS_0" },
        { "Triton", "https://www.youtube.com/embed/JXDiD2RwK-Q" },
        { "Nereid", "https://www.youtube.com/embed/3Ar-SA7W1Qs                                                                                                                                                                                " },
        { "Pluto", "https://www.youtube.com/embed/wqjHHYyrzxo" },
        { "Charon", "https://www.youtube.com/embed/EDWXqg-Np1I" },
        { "Nix", "https://www.youtube.com/embed/9NymwmhJPqY" },
        { "Hydra", "https://www.youtube.com/embed/vOHt4mkMWFk" },
        { "Kerberos", "https://www.youtube.com/embed/" },
        { "Styx", "https://www.youtube.com/embed/AWk9k0a1oU4" },
    };

            if (videoMap.ContainsKey(selected))
            {
                webFrame1.Attributes["src"] = videoMap[selected];
            }
            else
            {
                webFrame1.Attributes["src"] = ""; // Or default fallback
            }





            if (wikiLinks.ContainsKey(selected))
            {
                string url = wikiLinks[selected];
                string summary = await GetWikipediaSummaryAsync(url);
                TextBox1.Text = summary;
            }
            else
            {
                TextBox1.Text = "No information available.";
            }
        }
        private async Task<string> GetWikipediaSummaryAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(url);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var summaryNode = doc.DocumentNode.SelectSingleNode("//p[normalize-space(string()) != '']");
                if (summaryNode != null)
                {
                    return HtmlEntity.DeEntitize(summaryNode.InnerText.Trim());
                }

                return "Summary not found.";
            }
        }
        protected void Menu2_MenuItemClick1(object sender, MenuEventArgs e)
        {

            //string videoUrl = "";

            //// You can dynamically assign the YouTube video URL based on the selected menu item
            //switch (e.Item.Value)
            //{
            //    case "Mercury":
            //        videoUrl = "https://www.youtube.com/watch?v=AWk9k0a1oU4";  // Replace with actual video ID for Mercury
            //        break;
            //    case "Venus":
            //        videoUrl = "https://www.youtube.com/watch?v=9hM_suT5ge0";  // Replace with actual video ID for Venus
            //        break;
            //        // Add cases for other menu items as needed
            //}

            //// Set the src attribute for webFrame1 to embed the YouTube video
            //webFrame1.Attributes["src"] = videoUrl;

            //// Optionally, you can also update TextBox1 or other UI elements here
            //TextBox1.Text = "Video for " + e.Item.Text;


            if (Menu2.SelectedItem.Value == "Mercury")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Mercury_(planet)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/1.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }


                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Mercury.jpg";


                string videoUrl = "https://www.youtube.com/embed/rX_NCCpw5Uo";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Venus")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Venus";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/2.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "2.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/venus.jpg";
                string videoUrl = "https://www.youtube.com/embed/djP-IdHFQWU";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;

            }
            if (Menu2.SelectedItem.Value == "Earth")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Earth";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/3.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "3.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/earth.jpg";
                string videoUrl = "https://www.youtube.com/embed/KJwYBJMSbPI";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;

            }
            if (Menu2.SelectedItem.Value == "Moon")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Moon";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/4.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "4.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/moon.jpg";
                string videoUrl = "https://www.youtube.com/embed/6AviDjR9mmo";

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Mars")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Mars";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/5.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "5.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/mars.jpeg";
                string videoUrl = "https://www.youtube.com/embed/wFTGP7-n3J8";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Phobos")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Phobos";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/6.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "6.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/phobos.jpg";
                string videoUrl = "https://www.youtube.com/embed/3bbyHfBgwrE";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Deimos")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Deimos_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/7.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "7.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/deimos.jpg";
                string videoUrl = "https://www.youtube.com/embed/d493OKZbB6k";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Jupiter")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Jupiter";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/8.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "8.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/jupiter.jpg";
                string videoUrl = "https://www.youtube.com/embed/JRHwq1DIgbI";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Io")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Io_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/9.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "9.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/io.jpg";
                string videoUrl = "https://www.youtube.com/embed/98iCzrNRWmQ";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Europa")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Europa_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/10.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "10.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/europa.jpg";
                string videoUrl = "https://www.youtube.com/embed/-l9dawoTDqs";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Ganymede")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Ganymede_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/11.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "11.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/ganymede.jpg";
                string videoUrl = "https://www.youtube.com/embed/gkuRM04Ck8Y";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Callisto")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Callisto_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/12.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "12.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/callisto.jpg";
                string videoUrl = "https://www.youtube.com/embed/MQiniKAX8NQ";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Saturn")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Saturn";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/13.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "13.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/saturn.jpg";
                string videoUrl = "https://www.youtube.com/embed/33yOQsptNis";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Titan")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Titan_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/14.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "14.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Titan.jpeg";
                string videoUrl = "https://www.youtube.com/embed/5gQBKCpIV3A";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Enceladus")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Enceladus";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/15.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "15.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/enceladus.jpg";
                string videoUrl = "https://www.youtube.com/embed/Y35LTzFB-2E";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Rhea")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Rhea_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/16.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "16.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/rhea.jpg";
                string videoUrl = "https://www.youtube.com/embed/ce-AkRewzdo";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Mimas")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Mimas";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/17.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "17.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/mimas.jpg";
                string videoUrl = "https://www.youtube.com/embed/K6RqfZ8EB70";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Iapetus")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Iapetus_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/18.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "18.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/iapetus.jpg";
                string videoUrl = "https://www.youtube.com/embed/i9MbLl4lSUQ";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Uranus")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Uranus";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/19.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "19.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/uranus.jpg";
                string videoUrl = "https://www.youtube.com/embed/tCmC0XOKO5Q";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Titania")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Titania_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/20.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "20.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/titania.jpg";
                string videoUrl = "https://www.youtube.com/embed/NUy6Da5J-lY";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Oberon")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Oberon_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/21.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "21.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/oberon.jpg";
                string videoUrl = "https://www.youtube.com/embed/mJh9pmwaa20";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Ariel")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Ariel_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/22.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "22.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/ariel.jpg";
                string videoUrl = "https://www.youtube.com/embed/OBiz2CZFFj8";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Umbriel")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Umbriel";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/23.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "23.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/umbriel.jpg";
                string videoUrl = "https://www.youtube.com/embed/cTQJxog8MB8";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Miranda")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Miranda_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/24.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "24.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/miranda.jpg";
                string videoUrl = "https://www.youtube.com/embed/lpYl8XAPsKI";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Neptune")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Neptune";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/25.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "25.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/neptune.jpg";
                string videoUrl = "https://www.youtube.com/embed/c3itr-ERe3k";

                webFrame1.Src = videoUrl;
            }
            //if (Menu2.SelectedItem.Value == "Triton")
            //{
            //    //TextBox1.Text = "Mercury";
            //    //Image1.Load();
            //    string targetUrl = "https://en.wikipedia.org/wiki/Triton_(moon)";
            //    webFrame.Attributes["src"] = targetUrl;
            //    string filePath = Server.MapPath("~/App_Data/26.txt");

            //    if (File.Exists(filePath))
            //    {
            //        string content = File.ReadAllText(filePath);
            //        TextBox1.Text = content;
            //    }
            //    else
            //    {
            //        TextBox1.Text = "File not found.";
            //    }

            //    // Get the uploaded file and save it to the server
            //    filePath = "~/App_Data/" + "26.jpg";

            //    // Set the ImageUrl to the uploaded file path
            //   imgDisplay.ImageUrl = "https://vip-fargo.com/images/triton.jpg";
            //    string videoUrl = "https://www.youtube.com/embed/JXDiD2RwK-Q";  // Replace 'xyz123' with the actual video ID

            //    webFrame1.Src = videoUrl;
            //}
            if (Menu2.SelectedItem.Value == "Triton")
            {
                webFrame.Attributes["src"] = "https://en.wikipedia.org/wiki/Triton_(moon)";
                string filePath = Server.MapPath("~/App_Data/26.txt");

                if (File.Exists(filePath))
                    TextBox1.Text = File.ReadAllText(filePath);
                else
                    TextBox1.Text = "File not found.";

                imgDisplay.ImageUrl = "https://vip-fargo.com/images/triton.jpg";
                webFrame1.Attributes["src"] = "https://www.youtube.com/embed/qGy4uyHVUYA";



                // example YouTube video about Triton
            }
            if (Menu2.SelectedItem.Value == "Nereid")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Triton_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/27.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "26.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Nereid.jpg";
                string videoUrl = "https://www.youtube.com/embed/3Ar-SA7W1Qs";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Pluto")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Pluto";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/27.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "27.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/pluto.jpg";
                string videoUrl = "https://www.youtube.com/embed/wqjHHYyrzxo";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Charon")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Charon";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/28.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "28.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/charon.jpg";
                string videoUrl = "https://www.youtube.com/embed/EDWXqg-Np1I";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Nix")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Nix_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/29.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "29.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Nix.jpg";
                string videoUrl = "https://www.youtube.com/embed/9NymwmhJPqY";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Hydra")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Hydra_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/30.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "30.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Hydra.jpg";
                string videoUrl = "https://www.youtube.com/embed/vOHt4mkMWFk";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Kerberos")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Kerberos_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/31.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "31.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Kerberos.jpg";
                string videoUrl = "https://www.youtube.com/embed/9hM_suT5ge0";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;
            }
            if (Menu2.SelectedItem.Value == "Styx")
            {
                //TextBox1.Text = "Mercury";
                //Image1.Load();
                string targetUrl = "https://en.wikipedia.org/wiki/Styx_(moon)";
                webFrame.Attributes["src"] = targetUrl;
                string filePath = Server.MapPath("~/App_Data/32.txt");

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TextBox1.Text = content;
                }
                else
                {
                    TextBox1.Text = "File not found.";
                }

                // Get the uploaded file and save it to the server
                filePath = "~/App_Data/" + "32.jpg";

                // Set the ImageUrl to the uploaded file path
                imgDisplay.ImageUrl = "https://vip-fargo.com/images/Styx.jpg";
                string videoUrl = "https://www.youtube.com/embed/AWk9k0a1oU4";  // Replace 'xyz123' with the actual video ID

                webFrame1.Src = videoUrl;

            }


        }
    }
}