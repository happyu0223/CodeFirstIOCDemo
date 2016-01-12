using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstIOCDemo.Web.Models
{
    public partial class WebConstants
    {
        public static readonly Dictionary<string, object> DateTimeEditorAttributes;
        public static readonly Dictionary<string, object> DateEditorAttributes;
        public static readonly Dictionary<string, object> TimeEditorAttributes;
        public static readonly Dictionary<string, object> AddressEditorAttributes;
        public static readonly Dictionary<string, object> UrlEditorAttributes;
        public static readonly Dictionary<string, object> UserEditorAttributes;
        public static readonly Dictionary<string, object> HtmlEditorAttributes;
        public static readonly HttpStatusCodeResult HttpSuccess = new HttpStatusCodeResult(200);
        public static readonly HttpStatusCodeResult HttpError = new HttpStatusCodeResult(500);
        public static readonly HttpStatusCodeResult HttpNotAuthorized = new HttpStatusCodeResult(403);
        public const string Json = "application/json";
        public const string Text = "text/plain";
        public const string BinaryData = "application/octet-stream";
        public const string ApplicationExcel = "application/vnd.ms-excel";
        public const string ApplicationExcel2007 = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string QueryResultTableId = "query_result";
        public const string AddressEditorClass = "Address";
        public const int HtmlTextInListViewMaxLength = 20;
        public const string UserSetting = "UserSetting";
        public const string AvailableMenuMap = "AvailableMenuMap";

        public class ViewData
        {
            public const string Project = "Project";
        }

        public class Statistics
        {
            public const string RequirementStatistics = "req";

            public const string EarnedValue = "ev";
        }

        static WebConstants()
        {
            DateTimeEditorAttributes = new Dictionary<string, object>();
            DateTimeEditorAttributes.Add("class", "DateTimeClass");

            DateEditorAttributes = new Dictionary<string, object>();
            DateEditorAttributes.Add("class", "DateClass");

            TimeEditorAttributes = new Dictionary<string, object>();
            TimeEditorAttributes.Add("class", "TimeClass");

            AddressEditorAttributes = new Dictionary<string, object>();
            // SkipPropertyGeneration这个class是用在前台的javascript脚本 vowei.main.js 中的
            // submit_edit函数中，碰到这Category型的input控件，就跳过，因为会有其他函数来填充
            // 上传到服务器的对象。
            AddressEditorAttributes.Add("class", "SkipPropertyGeneration");

            UrlEditorAttributes = new Dictionary<string, object>();
            UrlEditorAttributes.Add("class", "UrlClass");

            UserEditorAttributes = new Dictionary<string, object>();
            UserEditorAttributes.Add("class", "UserClass");

            HtmlEditorAttributes = new Dictionary<string, object>();
            HtmlEditorAttributes.Add("class", "HtmlClass");
        }
    }
}