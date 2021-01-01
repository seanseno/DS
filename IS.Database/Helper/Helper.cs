using IS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace IS.Database
{
    public class Helper
    {
        private bool WindowsAuthentication = Convert.ToBoolean(ConfigurationManager.AppSettings["WindowsAuthentication"]);
        private string ConnectionString =  ConfigurationManager.AppSettings["ConnectionString"];
        private string ServerName = ConfigurationManager.AppSettings["ServerName"];
        private string Database = ConfigurationManager.AppSettings["Database"];
        private string UserId = ConfigurationManager.AppSettings["UserId"];
        private string Password = ConfigurationManager.AppSettings["Password"];

        public string DownloadPath = ConfigurationManager.AppSettings["DownLoadPath"];
        public bool IsEncrypt = Convert.ToBoolean(ConfigurationManager.AppSettings["Encrypt"]);

        public string ConStr
        {
            get
            {
                if (!WindowsAuthentication)
                {
                    string Cstring = String.Format("Server={0};Database={1};User Id={2};Password={3};MultipleActiveResultSets=true", ServerName, Database, Encryption.Decrypt(UserId), Encryption.Decrypt(Password));
                    return Cstring;
                }
                else
                {
                    return ConnectionString;
                }
            }
        }

        public int ExpirationAlert
        {
            get
            {
                ISFactory factory = new ISFactory();
                return factory.SettingsRepository.GetList()[0].ExpirationAlert;
            }
        }

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
