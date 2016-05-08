using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using ScrapySharp.Extensions;
using System.Data;
using System.Text.RegularExpressions;

namespace VibeStatusCompare
{
    internal class PageScrapper
    {

        private static PageScrapper instance;

        private PageScrapper() { }

        public static PageScrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageScrapper();
                }
                return instance;
            }
        }

        public DataTable GetDataTable(string url, string userName, string password)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument page = web.Load(url, "GET", new WebProxy(), new NetworkCredential(userName, password));

            HtmlNode[] nodes = page.DocumentNode.CssSelect("table").ToArray();

            DataTable table = new DataTable();
            
            TableBuilder(nodes, table);
            table.Columns.Add(new DataColumn("isError", typeof(bool)) { DefaultValue = false, ColumnName = "Error" });
            return table;



        }

        
        private static void TableBuilder(HtmlNode[] nodes, DataTable table)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                var rows = nodes[i].CssSelect("tr").ToArray();
                foreach (var row in rows)
                {
                    if (!Regex.IsMatch(row.InnerHtml, "<h3>"))
                    {
                        var fields = row.CssSelect("th");
                        foreach (var field in fields)
                        {
                            string colName = field.InnerText.Trim();
                            if (string.IsNullOrEmpty(colName))
                            {
                                colName = "newCol";
                            }
                            table.Columns.Add(field.InnerText.Trim(), typeof(string));
                        }
                    }

                    var values = row.CssSelect("td").ToArray();
                    if (values.Length > 0)
                    {
                        
                        DataRow newRow = table.NewRow();
                        for (int u = 0; u < values.Length; u++)
                        {
                            if (values[0].InnerText.Trim() == "")
                            {
                                return;
                            }

                            if (u < table.Columns.Count)
                            {
                                newRow[u] = values[u].InnerText.Trim();
                            }

                        }
                        table.Rows.Add(newRow);
                    }
                }

                

            }
        }
    }
}
