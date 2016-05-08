using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FailoverCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Comparrer _tables = new Comparrer();
        public MainWindow()
        {
            InitializeComponent();

           
           // ToggleAllowUnsafeHeaderParsing(true);
           

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

       
        private void OriginalLoad_Click(object sender, RoutedEventArgs e)
        {
            _tables.OriginalTable = PageScrapper.Instance.GetDataTable(SouceURL.Text, UserID.Text, Password.Password);
            SourceDataGrid.ItemsSource = _tables.GetSortedOriginalTable().DefaultView;
            TargetLoad.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _tables.TargetTable = PageScrapper.Instance.GetDataTable(targetURL.Text, targetUserID.Text, targetPassword.Password);
            _tables.Compare();

            SourceDataGrid.ItemsSource = _tables.GetSortedOriginalTable().DefaultView;
            TargetDataGrid.ItemsSource = _tables.GetSortedTargetTable().DefaultView;
        }

      
    }
}
