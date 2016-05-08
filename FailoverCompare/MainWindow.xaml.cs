using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScrapySharp.Extensions;
using HtmlAgilityPack;
using ScrapySharp.Network;
using ScrapySharp.Html.Forms;
using ScrapySharp.Html;

namespace FailoverCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //WebRequest request = WebRequest.Create("http://41.77.96.129:8081/cgi-bin/webif/vibe-status.sh");
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequired;
            //request.PreAuthenticate = true;
            //request.Credentials
            // Enable UseUnsafeHeaderParsing
            ToggleAllowUnsafeHeaderParsing(true);
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            //browser.UseDefaultCookiesParser = false;

            HtmlWeb webPage = new HtmlWeb();

            HtmlDocument homePage =    webPage.Load("http://41.77.96.129:8081/cgi-bin/webif/vibe-status.sh", "GET", new WebProxy(), new NetworkCredential("admin", "@bs0rb3r"));
                // 0, "admin", "@bs0rb3r"
            HtmlNode[] resultsLinks = homePage.DocumentNode.CssSelect("table tr").ToArray();


            for (int i = 0; i < resultsLinks.Length; i++)
            {
                var td = resultsLinks[i].CssSelect("td").ToArray();
                if (td.Length > 0)
                {
                    foreach (var item in td)
                    {
                        T1.Text += item.InnerText + Environment.NewLine;
                    }
                }
            }
            
        }




        // Enable/disable useUnsafeHeaderParsing.
        // See http://o2platform.wordpress.com/2010/10/20/dealing-with-the-server-committed-a-protocol-violation-sectionresponsestatusline/
        public static bool ToggleAllowUnsafeHeaderParsing(bool enable)
        {
            //Get the assembly that contains the internal class
            Assembly assembly = Assembly.GetAssembly(typeof(SettingsSection));
            if (assembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type settingsSectionType = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (settingsSectionType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created already invoking the property will create it for us.
                    object anInstance = settingsSectionType.InvokeMember("Section",
                    BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework if unsafe header parsing is allowed
                        FieldInfo aUseUnsafeHeaderParsing = settingsSectionType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, enable);
                            return true;
                        }

                    }
                }
            }
            return false;
        }
    }
}
