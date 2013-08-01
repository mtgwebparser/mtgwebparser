using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HtmlAgilityPack;
using System.IO;

namespace ExtractAllHrefFromHtmlSnippet
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // load snippet
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet = LoadHtmlSnippetFromFile();

            // extract hrefs
            List<string> hrefTags = new List<string>();
            hrefTags = ExtractAllAHrefTags(htmlSnippet);

            // bind to gridview
            GridViewHrefs.DataSource = hrefTags;
            GridViewHrefs.DataBind();
        }

        /// <summary>
        /// Load the html snippet from the txt file
        /// </summary>
        private HtmlDocument LoadHtmlSnippetFromFile()
        {
            TextReader reader = File.OpenText(Server.MapPath("~/App_Data/buylist5.htm"));

            HtmlDocument doc = new HtmlDocument();
            doc.Load(reader);

            reader.Close();

            return doc;
        }

        /// <summary>
        /// Extract all anchor tags using HtmlAgilityPack
        /// </summary>
        /// <param name="htmlSnippet"></param>
        /// <returns></returns>
        private List<string> ExtractAllAHrefTags(HtmlDocument htmlSnippet)
        {
            //List<string> hrefTags = new List<string>();

            //foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            //{
            //    HtmlAttribute att = link.Attributes["href"];
            //    hrefTags.Add(att.Value);
            //}

            //return hrefTags;

            List<string> hrefTags = new List<string>();
            string cardName = "";
            string price = "";
            bool isCard = true;
            int numCards = 0;

            //foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//td[text()='Deathrite Shaman' or text()='Deathrite Shaman (FOIL)']/text()"))
            //foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//td[@class='deckdbbody']/text()"))
            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//td[(@class='deckdbbody' or @class='deckdbbody2') and @align='left']"))
            {
                //HtmlAttribute att = link.Attributes["text"];
                //HtmlTextNode att = link.Attributes["text"];



                HtmlNode next = link.SelectSingleNode("following-sibling::td[1]");


                if (next != null)
                {
                    hrefTags.Add(link.InnerText.Trim() + " " + next.InnerText.Trim());
                }
                numCards++;
                


                //if (isCard)
                //{

                //    cardName = link.InnerText.Trim();
                //    isCard = false;
                //}
                //else
                //{
                //    price = link.InnerText.Trim();
                //    isCard = true;
                //}

                //if (cardName != "" && price != "")
                //{
                //    double num;
                //    if (double.TryParse(cardName, out num))
                //    {
                //        hrefTags.Add("INVALID " + cardName + " " + price);
                //    }
                //    else
                //    {
                //        hrefTags.Add(cardName + " " + price);
                //    }
                //    cardName = "";
                //    price = "";
                //}
            }

            hrefTags.Add(numCards.ToString());
            return hrefTags;
        }
    }
}
