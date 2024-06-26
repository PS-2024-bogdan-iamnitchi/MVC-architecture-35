﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace MVC_architecture_35.Language
{
    public static class LangHelper
    {
        private static ResourceManager _rm;

        static LangHelper()
        {
            _rm = new ResourceManager("MVC_architecture_35.Language.strings", Assembly.GetExecutingAssembly());
        }

        public static string GetString(string name)
        {
            return _rm.GetString(name);
        }

        public static void ChangeLanguage(string language)
        {
            var cultrueInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultrueInfo;
            CultureInfo.CurrentUICulture = cultrueInfo;
        }
    }
}
