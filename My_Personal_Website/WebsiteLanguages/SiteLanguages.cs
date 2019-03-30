using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace My_Personal_Website.WebsiteLanguages
{
    public class SiteLanguages
    {
        public static List<Language> AvailableLanguages = new List<Language>
        {
           
            new Language{LanguageName="Français",LanguageAbbr="fr"},
             new Language{LanguageName="English",LanguageAbbr="en"}
        };

        public static bool IsLanguageAvailable(string language)
        {
            return AvailableLanguages.Where(x => x.LanguageAbbr.Equals(language)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageAbbr;
        }

        public static string GetCurrentLanguageCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString();
        }

        public static string GetCurrentLanguageName()
        {
            string ln = "";
            switch(System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString())
            {
                case "en-US":
                    ln = "English";
                    break;
                case "fr-FR":
                    ln = "Français";
                    break;
            }
            return ln;
        }

        public void SetLanguage(string Language)
        {
            try
            {
                if (!IsLanguageAvailable(Language))
                {
                    Language = GetDefaultLanguage();
                }
                var cultureInfo = new CultureInfo(Language);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie languageCookie = new HttpCookie("culture", Language);
                languageCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(languageCookie);
            }
            catch
            {

            }
        }
    }


    public class Language
    {
        public string LanguageName { get; set; }
        public string LanguageAbbr { get; set; }
    }
}