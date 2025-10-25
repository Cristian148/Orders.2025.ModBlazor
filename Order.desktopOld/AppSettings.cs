using RuFramework.Config;
using RuFramework.LocalizedAttribute;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms.Design;
using System.Xml.Serialization;

/*
using RuFramework.Config;

namespace MyNamespace
{
    public partial class Form1 : Form
    {
         AppSettings appSettings = new AppSettings();
        
        public Form1()
        {
           #region Appsettings
            // ######################################################################################################
            // Initialize AppSettings
            // Set Location with AppDataPath
            //
            //                                   AppDataPath.                               // Defined in RuConfigManager
            //                                              .Common
            //                                              .ExePath                        // Only PortableApps
            //                                              .Local
            //                                              .Roaming
            // User config path
            // appSettings = RuConfigManager.Open(@"D:\My.config");                         // User config path
            // appSettings = RuFramework.Config.ConfigManager.Read(AppDataPath.Local);      // Set AppDataPath.Local

            appSettings =    RuFramework.Config.ConfigManager.Read();                       // Default AppDataPath.Roaming

            // Save properties with in open selected Path, Config is saved
            RuFramework.Config.ConfigManager.Save(appSettings);

            // Set cultir, change language with AppSettings.InstaledCultur
            Thread.CurrentThread.CurrentCulture = new CultureInfo(appSettings.InstaledCultur);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(appSettings.InstaledCultur);
            // ######################################################################################################
            #endregion
			
            InitializeComponent();
			
			// Insert in ResourceConfig
			// Custom tool = ResXFileCodeGenerator
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettingsDialog appSettingsDialog = new AppSettingsDialog(appSettings);
            appSettingsDialog.ShowDialog();
        }
    }
}
*/

namespace RuFramework.Config
{
    [XmlType(TypeName = "appSettings")]
    [Serializable]
    public class AppSettings : EventArgs
    {

        #region Language property
        // Declare in Forms
        // public AppSettings appSettings = new AppSettings();

        // Read AppSettings
        // appSettings = RuFramework.Config.ConfigManager.Read();   // Default AppDataPath.Roaming

        // Save properties with in open selected Path
        // RuFramework.Config.ConfigManager.Save(appSettings);

        // Init UI in PrppertyGrid
        // Thread.CurrentThread.CurrentCulture = new CultureInfo(appSettings.InstaledCultur);
        // Thread.CurrentThread.CurrentUICulture = new CultureInfo(appSettings.InstaledCultur);

        // Installed languages
        static readonly string[] Installedlanguages = { "de-DE", "en-US" };

        // Property InstaledCultur
        [LocalizedCategory("CategoryCultur", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [LocalizedAttribute.Localized("CulturDescription", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [LocalizedDisplayName("CulturDisplayName", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [TypeConverter(typeof(InstaledCulturConverter))]
        [Browsable(true)]
        public string InstaledCultur
        {
            set { instaledCultur = value; }

            //When first loaded set property with the first item in the InstaledCultur list.
            get
            {
                string S = "";

                if (instaledCultur != null)
                {
                    S = instaledCultur;
                }
                else
                {
                    // int _NumofRules = richTextBox1.Lines.Length;
                    int numOfInstaledCultur = Installedlanguages.Length;

                    ListOfInstaledCultur = new string[numOfInstaledCultur];
                    for (int i = 0; i <= numOfInstaledCultur - 1; i++)
                    {
                        //HE_GlobalVars._ListofRules[i] = richTextBox1.Lines[i];
                        ListOfInstaledCultur[i] = Installedlanguages[i];
                    }

                    if (ListOfInstaledCultur.Length > 0)
                    {
                        //Sort the list before displaying it
                        Array.Sort(ListOfInstaledCultur);

                        S = ListOfInstaledCultur[0];
                    }
                }
                return S;
            }
        }
        // Get value
        private string instaledCultur = null;

        // Display InstaledCultur in PropertyGrid
        public static string[] ListOfInstaledCultur;

        // This is required for the converter, here using the example of culture/language
        public void UpdateListofInstaledCultur()
        {
            int NumOfInstaledCultur = Installedlanguages.Length;

            ListOfInstaledCultur = new string[NumOfInstaledCultur];
            for (int i = 0; i <= NumOfInstaledCultur - 1; i++)
            {
                ListOfInstaledCultur[i] = Installedlanguages[i];
            }
        }
        #endregion

        #region other properties
        [LocalizedCategory("CategoryPerson", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [LocalizedAttribute.Localized("PersonDescription", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [LocalizedDisplayName("PersonDisplayName", typeof(Order.desktop.ConfigManager.ResourceConfig))]
        [Browsable(true)]

        public string Person { get; set; } = "Klaus";
        #endregion

    }
}