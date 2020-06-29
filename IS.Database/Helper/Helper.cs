using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace IS.Database
{
    public class Helper
    {
        public string ConStr =  ConfigurationManager.AppSettings["ConnectionString"];
        public string DownloadPath = ConfigurationManager.AppSettings["DownLoadPath"];
        public bool IsEncrypt = Convert.ToBoolean(ConfigurationManager.AppSettings["Encrypt"]);
        public void OverwriteValue(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings.Count == 0 | settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException exc)
            {
                //Logger.WriteLog(exc.Message, LoggingLevel.Error);
            }
        }
    }
}
