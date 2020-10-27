using IS.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace IS.Library.Utility
{
    public static class ThemesUtility
    {
        public static int Id()
        {
            ISFactory factory = new ISFactory();
            return factory.ThemesRepository.GetList().ToList().FirstOrDefault().Id;
        }
        public static string Logo()
        {
            ISFactory factory = new ISFactory();
            return factory.ThemesRepository.GetList().ToList().FirstOrDefault().Logo;
        }

        public static string WallPaper()
        {
            ISFactory factory = new ISFactory();
            return factory.ThemesRepository.GetList().ToList().FirstOrDefault().WallPaper;
        }

        public static Color BackColor()
        {
            ISFactory factory = new ISFactory();
            int r = factory.ThemesRepository.GetList().ToList().FirstOrDefault().Red;
            var g = factory.ThemesRepository.GetList().ToList().FirstOrDefault().Green;
            var b = factory.ThemesRepository.GetList().ToList().FirstOrDefault().Blue;
            return Color.FromArgb(r, g, b);
        }
        public static string CompanyName()
        {
            ISFactory factory = new ISFactory();
            return factory.ThemesRepository.GetList().ToList().FirstOrDefault().CompanyName;
        }

    }
}

