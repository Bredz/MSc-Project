
using Core.Common.Infrastructure.Alerts;
using Core.Common.Interfaces;
//using NIMS.Core.Utils.Enums;
using System;
//using System.Activities;
//using System.Activities.Validation;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
//using System.Web.ModelBinding;
using System.Web.Mvc;
//using System.Web.Routing;
//using System.Workflow.Activities.Rules;
using System.Web.Mvc.Ajax;
using System.Globalization;
using MastersProject.Core.Common.Interfaces;
using MastersProject.Core.Common.Infrastructure;
//using System.Workflow.Activities.Rules;
//using System.Workflow.ComponentModel;
//using System.Workflow.ComponentModel.Compiler;

namespace MastersProject.Core.Common.Utils
{
    public static class ExtensionMethods
    {
        const string Alerts = "_Alerts";
        /// <summary>
        /// As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack.
        /// You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments
        /// </summary>
        /// <param name="queryExpression">select * from [table] where [column]=@p0 and [column]=@p1</param>
        /// <param name="parameters">parameters for query</param>
        /// <returns></returns>
        public static System.Data.Entity.Infrastructure.DbRawSqlQuery<string>SQLQuery(this DbContext ctx, string queryExpression, params object[] parameters)
        {
            return  ctx.Database.SqlQuery<String>(queryExpression, parameters);
        }
        public static void EntityDebugger(this DbEntityValidationException ex)
        {
            Parallel.ForEach(ex.EntityValidationErrors, a => {
                Parallel.ForEach(a.ValidationErrors, b => {
                    Debug.Write(string.Format("ENTITY:{0}>>PROPERTY:{1},ERROR:{2}",a.Entry.Entity.ToString(),b.PropertyName,b.ErrorMessage));
                });    
            
            });

        }

        /// <summary>
        /// This converts a text to the proper case base on Pascal Casing...
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string type)
        {//"\w+"
            if (type != null)
            {
                Regex.Replace(type, "(\\B[A-Z])", " $1");
                return Regex.Replace(
        Regex.Replace(
            type,
            @"(\P{Ll})(\P{Ll}\p{Ll})",
            "$1 $2"
        ),
        @"(\p{Ll})(\P{Ll})",
        "$1 $2"
    );

               // StringBuilder sb = new StringBuilder();
                //type = type.Trim();
                //var sArry=type.Split(new char[] { ' ' });
                // List<string> tmp=new List<string>();
                //sArry.ToList().ForEach(a => {

                //  tmp.Add(a[0].ToString().ToUpper()+ a.Substring(1, a.Length - 1).ToLower());
                //});  
                //Regex reg = new Regex(@"\s");
                //Match m = reg.Match(type);
                //while (m.Success)
                //{
                //    int length = 0;
                //    //get next index
                //    if (m.NextMatch().Success)
                //        length = m.NextMatch().Index - m.Index;
                //    else
                //        length = type.Length - m.Index;
                //    //string tmp = m.Value.Trim();
                //    sb.Append( m.Value + type.Substring(m.Index + 1, length - 1).ToLower().Trim() + " ");

                //    m = m.NextMatch();
                //}
                //return type; //string.Join(" ",tmp.ToArray());
            }
            else { return String.Empty; }
        }

        public static string ReplaceUnderscores(this string type)
        {//"\w+"
            if (type != null)
            {

                // StringBuilder sb = new StringBuilder();
                
                return type.Replace("_"," ");
            }
            else { return String.Empty; }
        }

        /// <summary>
        /// Builds a bread crumb
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        //public static HtmlString BuildBreadCrumb(this HtmlHelper helper){
        //  var ctx = System.Web.HttpContext.Current ;
        //  var isAjax = new HttpRequestWrapper(ctx.Request).IsAjaxRequest();
        // string bKey = "_bcrumb";
        //  if (!isAjax)
        //  {
              
        //      System.Collections.Generic.Dictionary<string, string> routes = new Dictionary<string, string>();

        //      string value = ctx.Request.RequestContext.RouteData.Values["controller"].ToString()+" / "+ctx.Request.RequestContext.RouteData.Values["action"].ToString();
        //      string key = (value).ToLower(); 
        //      //proper casing
        //      value =value[0].ToString().ToUpper()+value.Substring(1, value.Length-1);
        //     //check if session has breadcrumb 
        //      if (ctx.Session[bKey] == null || key=="/home/index")
        //      {   //create it
        //          routes.Clear();
        //          routes.Add("/home/index", "Home");
        //          ctx.Session.Add(bKey, routes);
        //      }
        //      else
        //      {
        //          //get it
        //          routes = (System.Collections.Generic.Dictionary<string, string>)ctx.Session.Contents[bKey];

        //          //1.check if key is found
        //          //if (routes.ContainsKey(key))
        //          //{
        //          //    //1.1 if found remove items after index 

        //          //    int foundAt = -1;
        //          System.Collections.Generic.Dictionary<string, string> newTrail = new Dictionary<string, string>();
                
        //          newTrail.Add(routes.ElementAt(0).Key, routes.ElementAt(0).Value.ToTitleCase());//recreate home
        //         if (key != "home / index")
        //          newTrail.Add(key,value.ToTitleCase());
                 
        //          ctx.Session[bKey] = newTrail;
        //          //for (int index = 1; index < routes.Count; index++)
        //          //{

                      
        //          //    //if (routes.ElementAt(index).Key == key)
        //          //    //{
        //          //    //    foundAt = index;
        //          //    //    break;
        //          //    //}
        //          //}
        //          //    //remove everything after
                      
        //          //    for (int i = 0; i <= foundAt; i++)
        //          //    {
        //          //        //get element
        //          //        var tmp = routes.ElementAt(i);
        //          //        //routes.Remove(routes.ElementAt(i).Key);
        //          //        newTrail.Add(tmp.Key, tmp.Value.ToTitleCase());
        //          //    }
        //          //    //update session object
        //          //    ctx.Session[bKey] = newTrail;
        //          //}
        //          //else
        //          //{
                 
        //              //2.If not found add pair
        //             // routes.Add(key, value.ToTitleCase());
        //              //update session object
        //             // ctx.Session[bKey] = routes;
        //         // }
        //      }
        //      //build breadcrumb
        //      return DrawTrail(ctx, bKey);
        // }
        //  else
        //  {
        //      return DrawTrail(ctx, bKey);

        //  }
        //}

        //private static HtmlString DrawTrail(HttpContext ctx, string bKey)
        //{
        //    var rArray = ((System.Collections.Generic.Dictionary<string, string>)ctx.Session[bKey]).ToArray();
        //    StringBuilder crumbTrail = new StringBuilder("<ul class='page-breadcrumb breadcrumb'>");
        //    for (int i = 0; i < rArray.Length; i++)
        //    {
        //        var bSlice = rArray.ElementAt(i);
        //        //Assume home
        //        if (i == 0)
        //        {
        //            crumbTrail.Append("<li>");
        //            crumbTrail.Append("<i class='fa fa-home'></i>");
        //            crumbTrail.Append("<a href='" + bSlice.Key + "'>"+ bSlice.Value+"</a>");
        //            crumbTrail.Append("<i class='fa fa-angle-right'></i></li>");

        //        }
        //        else
        //        {

        //            crumbTrail.Append("<li>");


        //            if (i != rArray.Length - 1)
        //            {
        //                crumbTrail.Append("<a href='" + bSlice.Key + "'>" + bSlice.Value + "</a>");
        //                crumbTrail.Append("<i class='fa fa-angle-right'></i>");
        //            }
        //            else
        //            {
        //                crumbTrail.Append( bSlice.Value );
        //            }

        //            crumbTrail.Append("</li>");


        //        }

        //    }
        //    crumbTrail.Append("</ul>");
        //    //string t = rArray.ElementAt(0).Value;
        //    HtmlString t = new HtmlString(crumbTrail.ToString());
        //    return  t;
        //}
        /// <summary>
        /// Generate AJAX enabled Button
        /// </summary>
        /// <param name="ImageUrl">eg: ../Content/Images/AddUser16x16.png</param>
        /// <param name="OnBegin">eg: addItem('1')</param>
        /// Author:Richard Wier
        /// <returns></returns>
        public static string GenerateAjaxCommand(String title, String ImageUrl, String OnBegin, String ServerURL = "", String confirmMessage = "", Boolean post = false, String OnSuccess = "")
        {


            //Boolean isRelPath=ImageUrl.Split(new char[] { '/' })[0]== "~"? true:false;
            //Uri.TryCreate(ImageUrl, UriKind.RelativeOrAbsolute, out newUri); 
            //new string[] {"NISPayment"}var lst=ServerURL.Split(); : newUri.MakeRelativeUri(newUri).ToString()
            var button = String.Format("<a style='width:16px; height:16px' data-ajax='true' data-ajax-begin='{1}' title='{2}' {3} {4} {5} {6} href='#'><img src='{0}' alt='{2}' style='border:none' width='16px' height='16px'></a>",
               ImageUrl,
                OnBegin.Replace("'", "&#39;"),
                title,
                !String.IsNullOrEmpty(confirmMessage) ? "data-ajax-confirm='" + confirmMessage + "'" : String.Empty,
                post ? "data-ajax-method='POST'" : String.Empty,
                String.IsNullOrEmpty(OnSuccess) ? String.Empty : "data-ajax-success='" + OnSuccess + "'",
                !String.IsNullOrEmpty(ServerURL) ? "data-ajax-url='" + ServerURL + "'" : String.Empty);
            return button;
        }

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing=false)
        {

            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "DWRP66utec12015";

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
        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="cipherString"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing=false)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "DWRP66utec12015";

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

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        
        
        public static  IEnumerable<T> HighLighter<T>(this IEnumerable<T> ListToInspect,string[] searchTerms, params string[] fields)
        {
            Parallel.ForEach(ListToInspect,curItem=>{
                //get the type of this object
                Type _type = curItem.GetType();
                //get all properties based on fields supplied
                PropertyInfo[] _properties = _type.GetProperties().Where(p=>fields.Any(f=>f.ToLower()==p.Name.ToLower())).Select(a=>a).ToArray();
                Parallel.ForEach(_properties, p =>
                    {
                        object _value = p.GetValue(curItem, null);
                        //get property type
                        Type _propType = _value.GetType();
                        if (_propType.Name == "String" && _value != null)
                        {
                            Parallel.ForEach(searchTerms, currentKW =>
                            {

                                p.SetValue(curItem, Regex.Replace((String)_value, currentKW, "<span style='background-color:#247B06;color:#FFF'>" + currentKW + "</span>"),null);

                            });

                        }
                            //p.SetValue(curItem, Regex.Replace(_value, currentKW, "<span style='background-color:#247B06;color:#FFF'>" + currentKW + "</span>"), null);
                    });
                //foreach (var p in _properties)
                //{
                //    object _value = p.GetValue(ListToInspect, null);
                //    //get property type
                //    Type _propType = _value.GetType();
                //    if (_propType.Name == "String" && _value != null)
                //        p.SetValue(ListToInspect, _value.ToString().Trim(), null);
                //}
            });
            return ListToInspect;
           
            //Parallel.ForEach(rs, currentItem =>
            //{
            //    Parallel.ForEach(listOfStrings, currentKW => {

            //        currentItem.SearchResultSummary = Regex.Replace(currentItem.SearchResultSummary, currentKW, "<span style='background-color:#247B06;color:#FFF'>" + currentKW + "</span>");

            //    });
            //});
        }
        public static void TrimStringProperties(this object classToInspect)
        {
            //get the type of this object
            Type _type = classToInspect.GetType();
            //get all public properties for this type
            PropertyInfo[] _properties = _type.GetProperties();
            foreach (var p in _properties)
            {
                object _value = p.GetValue(classToInspect,null);
                //get property type
                Type _propType = _value.GetType();
                if(_propType.Name=="String" && _value!=null)
                   p.SetValue(classToInspect,_value.ToString().Trim(),null);
            }
        }

        public static void UpdateRowVersion(this object classToInspect)
        {
            //get the type of this object
            Type _type = classToInspect.GetType();
            //get all public properties for this type
            PropertyInfo[] _properties = _type.GetProperties();
            var rp=_properties.Where(p => p.Name.ToLower() == "rowversion").FirstOrDefault();
            if(rp!=null)
            {
                    var rv=DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    byte[] bytes = new byte[rv.Length * sizeof(char)];
                    System.Buffer.BlockCopy(rv.ToCharArray(), 0, bytes, 0, bytes.Length);
                    rp.SetValue(classToInspect,bytes , null);
            }
            
        }

        /// <summary>
        /// This method does a recursive walk of the exception call stack
        /// </summary>
        /// <param name="exceptionToExamine"></param>
        /// <returns></returns>
        public static string GetParentToChildExceptionStack(this Exception exceptionToExamine)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                do
                {
                    sb.Append("EXCEPTION TYPE:"+ Environment.NewLine);
                    sb.Append(exceptionToExamine.GetType().Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("MESSAGE:" + Environment.NewLine);
                    sb.Append(exceptionToExamine.Message + Environment.NewLine);
                    sb.Append("STACK TRACE:" + Environment.NewLine);
                    sb.Append(exceptionToExamine.StackTrace + Environment.NewLine);
                    sb.Append("".PadLeft(70,'=') + Environment.NewLine);
                    exceptionToExamine = exceptionToExamine.InnerException;

                } while (exceptionToExamine!=null );

                return sb.ToString();
            }
            finally
            {

                sb = null;
            }
        }
       
        /// <summary>
        /// This will examine the entities in the change tracker and check if each entity implements IObjectState
        /// it is nescessary for entities to implement this interface, this is how the api deals with updating graphs in Entity Framework
        /// </summary>
        /// <remarks>
        /// Create partial classes of each entity and implement IObjectState
        /// </remarks>
        /// <example>
        ///public partial class Applicant:NIMS.Common.Interfaces.IObjectState{
        ///private Common.Enums.ObjectState _state;
        ///public Common.Enums.ObjectState State
        ///{
        ///get{return _state;}
        ///set{_state = value;}
        ///}}
        /// Data.Applicant ap=new Data.Applicant { State= Common.Enums.ObjectState.Added};
        /// </example>
        /// <param name="dbContext">context in question</param>
        public static void ApplyStateChanges(this DbContext dbContext)
        {
            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                var entityState = dbEntityEntry.Entity as IObjectState;
                if (entityState == null)
                    throw new InvalidCastException(
                        "All entites must implement " +
                        "the IObjectState interface, this interface " +
                        "must be implemented so each entity's state " +
                        "can explicitly be determined when updating graphs.");

	            
                dbEntityEntry.State =Utils.ConvertState(entityState.State);
            }
       }
       
        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<Alert>();

            }
            return (List<Alert>)tempData[Alerts];
        }

        public static ActionResult WithInfo(this ActionResult result, string message, bool isTimedOut = true)
        {
            return new AlertDecoratorResult(result, "alert-info", message,isTimedOut);
        }
        public static ActionResult WithWarning(this ActionResult result, string message,bool isTimedOut=true)
        {
            return new AlertDecoratorResult(result, "alert-warning", message,isTimedOut);
        }
        public static ActionResult WithError(this ActionResult result, string message, bool isTimedOut = true)
        {
            return new AlertDecoratorResult(result, "alert-danger", message,isTimedOut);
        }
        public static ActionResult WithSuccess(this ActionResult result, string message, bool isTimedOut = true)
        {
            return new AlertDecoratorResult(result, "alert-success", message,isTimedOut);
        }

        public static string FileExtensionForContentType(this string fileName)
        {
            var pieces = fileName.Split('.');
            var extension = pieces.Length > 1 ? pieces[pieces.Length - 1] : string.Empty;
            return (extension.ToLower() == "jpg") ? "jpeg" : extension;
        }
        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue,bool excludeStaticKeys)
        {
            string[] excld = new string[] { "AccountType", "Parishes", "MaritalStatus", "Gender", "Title", "Country", "AddressType", "Rate", "DscEmpType", "ContributionSource", "EmploymentType", "ImportFileType", "EmployerStatus", "NotificationType", "VerificationType", "NoteEntity", "EntityType", "Process", "ContactEntity", "ParentType", "AddressType", "ClaimType", "ClaimStatus", "PaymentStatus", "ImportSourceType" };
            var tmp=(from Enum e in Enum.GetValues(enumValue.GetType())
                      select new SelectListItem
                   {
                       Selected = e.Equals(enumValue),
                       Text = e.ToDescription(),
                       Value = e.ToString()
                   }).OrderBy(a=>a.Text);

         return  tmp.ToList().Where(a=>!excld.Any(b=>b==a.Value)).OrderBy(a=>a.Text);
            

        }

        /// <summary>
        /// Use HTML in action links
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="action"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        //public static IHtmlString NoEncodeActionLink(this AjaxHelper ajaxHelper, string linkText, string action, string controller, object ajaxoptions, object routevalues)
        //{
        //    //TagBuilder builder;
        //    //UrlHelper urlHelper;
        //    //urlHelper = new UrlHelper(ajaxHelper.ViewContext.RequestContext);
        //    //builder = new TagBuilder("a");
        //    //builder.InnerHtml = linkText;
        //    //builder.Attributes["href"] = urlHelper.Action(action);
        //    //builder.MergeAttributes(new RouteValueDictionary(routevalues));
        //    //return MvcHtmlString.Create(builder.ToString());
        //    var repID = Guid.NewGuid().ToString();
        //    var lnk = ajaxHelper.ActionLink(repID, action, controller,ajaxoptions, routevalues);
        //    return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        //}

        public static int WeeksInYear(this DateTime date)
        {
            //int[] moveByDays = { 6, 7, 8, 9, 10, 4, 5 };
            //DateTime startOfYear = new DateTime(date.Year, 1, 1);
            //DateTime endOfYear = new DateTime(date.Year, 12, 31);
            //// ISO 8601 weeks start with Monday 
            //// The first week of a year includes the first Thursday 
            //// This means that Jan 1st could be in week 51, 52, or 53 of the previous year...
            //int numberDays = date.Subtract(startOfYear).Days +
            //                moveByDays[(int)startOfYear.DayOfWeek];
            //int weekNumber = numberDays / 7;
            //switch (weekNumber)
            //{
            //    case 0:
            //        // Before start of first week of this year - in last week of previous year
            //        weekNumber = WeekOfYear(startOfYear.AddDays(-1));
            //        break;
            //    case 53:
            //        // In first week of next year.
            //        if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
            //        {
            //            weekNumber = 1;
            //        }
            //        break;
            //}
            //return weekNumber;
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(new DateTime(date.Year, 12, 28), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static MvcHtmlString NoEncodeActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, System.Web.Mvc.Ajax.AjaxOptions ajaxOptions,object htmlAttributes=null)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions,htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        } 

        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }

    }
}
