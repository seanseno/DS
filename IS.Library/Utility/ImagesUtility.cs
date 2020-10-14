using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace IS.Library.Utility
{
    public static class ImagesUtility
    {
        public static void SaveCashierPhoto(string CashierId,string CopyPath)
        {
            if(!string.IsNullOrEmpty(CopyPath))
            {
                var Path = System.IO.Directory.GetCurrentDirectory();
                string Root = Path + "\\Images\\CashierPhoto\\";
                string FilePath = Root + CashierId + ".jpg";
                // If directory does not exist, create it. 
                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                File.Copy(CopyPath, FilePath, true);
            }
        }
        public static string LoadCashierPhoto(string CashierId)
        {
            var Path = System.IO.Directory.GetCurrentDirectory();
            string TruePhoto = Path + "\\Images\\CashierPhoto\\" + CashierId + ".jpg";
            return TruePhoto;
        }

        public static bool PhotoIsExist(string CashierId)
        {
            var Path = System.IO.Directory.GetCurrentDirectory();
            string TruePhoto = Path + "\\Images\\CashierPhoto\\" + CashierId + ".jpg";
            if (File.Exists(TruePhoto))
            {
                return true;
            }
            return false;
        }
    }
}

