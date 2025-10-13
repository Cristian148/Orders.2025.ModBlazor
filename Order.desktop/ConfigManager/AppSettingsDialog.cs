
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RuFramework.Config
{
    public partial class AppSettingsDialog : Form
    {
        #region Init
        string ConfigPath = null;
        public AppSettings AppSettingsOk = new AppSettings();
        /// <summary>
        /// Open the dialog with the Propertygrid.
        /// Select the Propertygrid on the config data.
        /// Remember the storage path of the config, default is Roaming.
        // AppDataPath.Local   = C:\users\UserName\AppData\Local\ProductName\ProductName\ProductVersion\ProductName.Config
        // AppDataPath.Roaming = C:\users\UserName\AppData\Roaming\ProductName\ProductName\ProductVersion\ProductName.Config
        // AppDataPath.Common  = C:\ProgramData\ProductName\ProductName\ProductVersion\ProductName.Config
        // AppDataPath.ExePath = ProductSaveDirectory\ProductName.Config, only PortableApps
        // default             = Roaming
        /// </summary>
        /// <param name="appSettings">The config data</param>
        /// <param name="configPath">The storage path of the config</param>
        public AppSettingsDialog(AppSettings appSettings, AppDataPath appDataPath = AppDataPath.Roaming)
        {
            InitializeComponent();

            // Initializes the editor for the Cultur/language selection
            appSettings.UpdateListofInstaledCultur();

            // Init propertygrid with appSetting
            propertyGrid.SelectedObject = appSettings;

            // Get the ConfigPath
            ConfigPath = ConfigManager.GetAppDataPath(appDataPath);
        }
        #endregion
        #region Clicked
        /// <summary>
        /// The menu Ok/Cancel clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                // The changed config data is saved
                case "Ok":
                    ConfigManager.Save((AppSettings)this.propertyGrid.SelectedObject, AppDataPath.Roaming);
                    break;
                // The changes are canceld
                case "Cancel":
                    break;
                default:
                    break;
            }
            this.Close();
        }
        /// <summary>
        /// The config is new reread.
        /// For Ok, it's the changed data.
        /// At Cancel, the source data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppSettingsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            // This data is returned
            AppSettingsOk = ConfigManager.Read(AppDataPath.Roaming);
        }
        #endregion
    }
}
