
using Core.Common.Enums;
using MastersProject.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
//using Core.Common.Utils.ExtensionMethods;

namespace MastersProject.Core.Common.Utils
{
    public static class Utils
    {
        public static string GenerateStatisticsTile(string title,object figure,string fontIcon,string tileColor)
        {
            string bg="";
            if (tileColor[0] == '#')
            {
                bg = tileColor;
                tileColor = "";
            }

            
            string t = "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
               " <div class='dashboard-stat " + tileColor + "' style='background-color:"+ bg +"'>" +
                   " <div class='visual'>" +
                        "<i class='fa " + fontIcon + "'></i></div>" +
                "<div class='details'><div class='number' style='font-size:20px;'>" + figure + "</div>" +
                "<div class='desc'>" +
                    title +
                "</div></div></div></div>";
            return t;
           
        }
        public static string GenerateAjaxCommand(string tooltip, string url,string fontIcon)
        {
            
            var button=string.Format("<a href='#' class='tooltips' title='{0}' data-placement='top' data-original-title='{0}' onclick='{1}'><i class='fa  {2}'></i></a>",tooltip,url.Replace("'", "&#39;"),fontIcon);
            return button;
        }
        public static string GenerateAjaxInlineCommand(string Controlid, string tooltip, String ServerURL, String confirmMessage, String OnSuccess,string fontIcon, Boolean post = false)
        {
            //&#39;{4}&#39;
            var button = string.Format("<a href='#' id='{4}' title='{0}' class='tooltips' data-ajax-url='{1}' data-ajax-confirm='{3}' data-ajax-success='{2}' data-placement='top' data-original-title='{0}' onclick='window.inlinePost(this)'><i class='fa {5}'></i></a>", tooltip, ServerURL, OnSuccess, confirmMessage, Controlid, fontIcon);
            return button;
        }
        public static string GenerateAjaxRemoveCommand(string Controlid, string tooltip, String ServerURL, String confirmMessage, String OnSuccess, Boolean post = false)
        {
            //&#39;{4}&#39;
            var button = string.Format("<a href='#' id='{4}' class='tooltips' data-ajax-url='{1}' data-ajax-confirm='{3}' data-ajax-success='{2}' data-placement='top' data-original-title='{0}' onclick='window.inlinePostOther(this)'><i class='fa  fa-trash-o red edit_icon'></i></a>", tooltip, ServerURL, OnSuccess, confirmMessage, Controlid);
            return button;
        }
        public static string GenerateAjaxEditCommand(string Controlid, string tooltip, String ServerURL, String confirmMessage, String OnSuccess, Boolean post = false)
        {
            //&#39;{4}&#39;
            var button = string.Format("<a href='#' id='{4}' class='tooltips' data-ajax-url='{1}' data-ajax-confirm='{3}' data-ajax-success='{2}' data-placement='top' data-original-title='{0}' onclick='window.inlinePostOther(this)'><i class='fa  fa-edit edit_icon'></i></a>", tooltip, ServerURL, OnSuccess, confirmMessage, Controlid);
            return button;
        }
        public static string GenerateAjaxCommand(string Controlid, string tooltip, String ServerURL, String confirmMessage, String OnSuccess,Boolean post = false)
        {
            //&#39;{4}&#39;
            var button = string.Format("<a href='#' id='{4}' class='tooltips' data-ajax-url='{1}' data-ajax-confirm='{3}' data-ajax-success='{2}' data-placement='top' onclick='window.inlinePostOther(this)'>{0}</a>", tooltip, ServerURL, OnSuccess, confirmMessage, Controlid);
            return button;
        }
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {

            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "003896mlss872334";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
       

        public static string GetModelErrors(ModelStateDictionary md)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ModelState modelState in md.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
            }
            return sb.ToString();
            //return error
        }
        public static Dictionary<string, string> SendMail(MailMessage[] mails)
        {
            
            Dictionary<string, string> _ereport = new Dictionary<string, string>();
            using (SmtpClient _client = new SmtpClient())
            {
                foreach (var m in mails)
                {
                    try
                    {
                        _client.Send(m);
                    }
                    catch (SmtpException smtpex)
                    {
                        if (m.To.Count > 1)
                        {
                            _ereport.Add("Bulk mail", smtpex.Message);
                        }
                        else
                            _ereport.Add(m.To[0].Address, smtpex.Message);

                    }

                }
            }
            return _ereport;
        }
        /// <summary>
        /// Use this to return a generic friendly error message for UI purposes
        /// </summary>
        /// <param name="eType"></param>
        /// <param name="additionalInfo"></param>
        /// <returns></returns>
        public static string GenericErrorMessage(ErrorMessageType eType, string additionalInfo = "")
        {
            switch (eType)
            {
                case ErrorMessageType.LoadingData:
                    return "Error while retreiving data..." + additionalInfo;
                    break;
                case ErrorMessageType.WritingData:
                    return "Error while writing data..." + additionalInfo;
                    break;
                case ErrorMessageType.DeletingData:
                    return "Error while deleting data..." + additionalInfo;
                    break;
                case ErrorMessageType.Concurrency:
                    return "The record you attempted to edit was modified by another user after you got the original value. The edit operation was cancelled,reload the data and try again..." + additionalInfo;
                    break;
                default:
                    return "Error while performing operation..." + additionalInfo;
                    break;
            }

        }
        public static class SearchHelper
        {
            public static Boolean AnyMatch(String keyword, params Object[] fields)
            {
                keyword = keyword.ToUpper();
              
                foreach (Object field in fields)
                {
                    if (field != null)
                    {
                        var strVal = field.ToString().ToUpper();
                        if (strVal.Contains(keyword))
                            return true;
                    }
                }

                return false;
            }
        }
        public static IEnumerable<SelectListItem> GenderSelectList()
        {
            List<SelectListItem> names = new List<SelectListItem>();
            var Values = Enum.GetValues(typeof(Core.Common.Enums.Gender));

            foreach (int value in Values)
            {  
                names.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(Core.Common.Enums.Gender), value),
                    Value = value.ToString()
                });
            }

            return names;
        }

        public static IEnumerable<SelectListItem> EnumSelectList(Type myEnum)
        {
            List<SelectListItem> names = new List<SelectListItem>();
            
            var Values = Enum.GetValues(myEnum);
            
            foreach (int value in Values)
            {
                names.Add(new SelectListItem
                {
                    Text = (Enum.Parse(myEnum, value.ToString()) as Enum).ToDescription(),
                    Value = value.ToString()
                });
            }

            return names;
        }

        public static IEnumerable<SelectListItem> TitleSelectList()
        {
            List<SelectListItem> names = new List<SelectListItem>();
            var Values = Enum.GetValues(typeof(Core.Common.Enums.Title));
            foreach (int value in Values)
            {
                names.Add(new SelectListItem
                {
                    Text = ((Core.Common.Enums.Title) value).ToDescription(),
                    Value = value.ToString()
                });
            }

            return names;
        }


        /// <summary>
        /// When saving from the unit of work class, this method converts entities that implement IObjectState to EntityState 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static class DropdownHelper
        {
            //value is text
            public static IEnumerable<SelectListItem> GetEnumTextItems<T>() where T : struct
            {
                T t = default(T);
                IEnumerable<SelectListItem> names = new List<SelectListItem>();
                var nameList = t.GetType().GetEnumNames();//Get List of values
                

                if(nameList!=null && nameList.Length>0)
                    names = t.GetType().GetEnumNames().Select(item=>new SelectListItem{Text = item, Value = item, });
              
                return names;
            }



            //value is numeric
            //public static IEnumerable<SelectListItem> GetEnumNumericItems<T>() where T : struct
            //{
            //    T t = default(T);
            //    List<SelectListItem> values = new List<SelectListItem>();
            //    string[] nameList = t.GetType().GetEnumNames();//Get List of values
            //   // var valueList = ;
            //    var valueList = t.GetType()..GetEnumValues();

            //    for (int i = 0; i < nameList.Length;i++)
            //        values.Add(new SelectListItem { Text = nameList[i], Value = (int)valueList.GetValue(i)});
            //    return values.AsEnumerable();
            //}

            //public static IEnumerable<string> GetNames<T>() where T : struct
            //{
            //    T t = default(T);
                
            //    return t.GetType().GetEnumNames().AsEnumerable();
            //}

            //public static IEnumerable<int> GetValues<T>() where T : struct
            //{
            //    T t = default(T);

            //    return t.GetType().GetEnumValues().Cast<int>();
            //}


        }

        //Converts datetime to timestamp
        public static long GetJavascriptTimestamp(int input)
        {
            DateTime val = new DateTime(input, 1, 1);
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = val.Subtract(span);
            return (long)(time.Ticks / 10000);
        }

    }
}
