using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http.Filters;

namespace GMK.OperationSystem.WFProxy.Infrastructure
{
    public class CustomAuthentication : IAuthenticationFilter
    {
        //private static ManagersProvider AnonymousManagersProvider = new ManagersProvider();

        Task IAuthenticationFilter.AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            var task = Task.FromResult(0);
            //var routeData = context.ActionContext.ControllerContext.RequestContext.RouteData;
            //AccessToken data = null;

            //string msg_signature = HttpContext.Current.Request.QueryString["msg_signature"];
            //string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            //string nonce = HttpContext.Current.Request.QueryString["nonce"];

            //// Override the authentication if POST from WeChat to server of enterprise
            //if ((!string.IsNullOrEmpty(msg_signature)) && !string.IsNullOrEmpty(timestamp) && !string.IsNullOrEmpty(nonce) && HttpContext.Current.Request.HttpMethod == "POST")
            //{
            //    var bytes = new byte[HttpContext.Current.Request.InputStream.Length];
            //    HttpContext.Current.Request.InputStream.Read(bytes, 0, bytes.Length);
            //    HttpContext.Current.Request.InputStream.Position = 0;
            //    string requestInput = Encoding.UTF8.GetString(bytes);

            //    string token = ConfigurationManager.AppSettings["WeChatToken"];
            //    string encodingAESKey = ConfigurationManager.AppSettings["WeChatEncodingAESKey"];
            //    string corpId = ConfigurationManager.AppSettings["WeChatCorpId"];

            //    string result = string.Empty;
            //    WeChatCallbackMessageCrypt encrypt = new WeChatCallbackMessageCrypt(token, encodingAESKey, corpId);
            //    int veryfyResult = encrypt.DecryptMsg(msg_signature, timestamp, nonce, requestInput, ref result);
            //    if (string.IsNullOrEmpty(result))
            //    {
            //        LogHelper.LogInformation("AuthenticateAsync: result is null!");
            //    }

            //    if (veryfyResult != (int)WeChatCallbackMessageCryptErrorCode.WeChatCallbackMessageCrypt_OK)
            //    {
            //        LogHelper.LogInformation("AuthenticateAsync: ErrorCode: " + veryfyResult.ToString());
            //    }

            //    XElement element = XElement.Parse(result);

            //    string userWeChatId = element.Element("FromUserName").Value.Trim();
            //    string eventKey = element.Element("EventKey").Value.Trim();
            //    if (!AnonymousManagersProvider.UserManager.LoginFromWeChat(corpId, userWeChatId, eventKey).Status)
            //    {
            //        context.ErrorResult = new UnauthorizedWithTextActionResult(new List<AuthenticationHeaderValue> { }, context.Request) { Message = "非法访问" };
            //        return task;
            //    }

            //    var user = AnonymousManagersProvider.UserManager.GetByWeChatId(userWeChatId);
            //    var identity = new CustomizeIdentity(user.LoginName);
            //    identity.CorporationId = 0;
            //    identity.CommodityList = new CommodityManager(new UserInfo() { CorporationId = 0, UserId = user.WFUserId, Username = user.LoginName }).List().Select(p => p.WFCommodityId).ToList();

            //    var userManager = new UserManager(new UserInfo() { UserId = user.WFUserId, Username = user.LoginName });
            //    var accountEnityList = userManager.GetUserAccountEntity();
            //    var accountEntityIdList = accountEnityList == null ? null : accountEnityList.Select(r => r.WFAccountEntityId).ToList();

            //    identity.AccountList = accountEntityIdList;
            //    identity.UserType = user.UserType.Value;
            //    identity.UserId = user.WFUserId;
            //    context.Principal = new CustomizePrincile(identity, null);
            //    return task;
            //}

            //var qs = context.ActionContext.Request.GetQueryNameValuePairs();
            //if (!qs.Any(m => "access_token".Equals(m.Key, StringComparison.InvariantCultureIgnoreCase)))
            //{
            //    context.ErrorResult = new UnauthorizedWithTextActionResult(new List<AuthenticationHeaderValue> { }, context.Request) { Message = "非法访问" };
            //    return task;
            //}

            //if (AccessToken.TryParse(qs.First(m => "access_token".Equals(m.Key, StringComparison.InvariantCultureIgnoreCase)).Value, out data))
            //{
            //    if (!data.IsValid())
            //    {
            //        context.ErrorResult = new UnauthorizedWithTextActionResult(new List<AuthenticationHeaderValue> { }, context.Request) { Message = "登录信息已过期，请重新登录" };
            //        return task;
            //    }
            //    JavaScriptSerializer jss = new JavaScriptSerializer();
            //    var userId = int.Parse(data.UserId);
            //    var identity = new CustomizeIdentity(AnonymousManagersProvider.UserManager.GetById(userId).LoginName);
            //    identity.CorporationId = Convert.ToInt32(data.CorporationId);
            //    if (!string.IsNullOrWhiteSpace(data.CommodityList)) identity.CommodityList = (ICollection<int>)jss.Deserialize(data.CommodityList, typeof(IEnumerable<int>));
            //    identity.AccountList = string.IsNullOrWhiteSpace(data.AccountList) ? null : (List<int>)jss.Deserialize(data.AccountList, typeof(IEnumerable<int>));
            //    identity.UserType = int.Parse(data.UserType);
            //    identity.UserId = int.Parse(data.UserId);
            //    context.Principal = new CustomizePrincile(identity, null);
            //}
            //else
            //{
            //    context.ErrorResult = new UnauthorizedWithTextActionResult(new List<AuthenticationHeaderValue> { }, context.Request) { Message = "未授权访问" };
            //}

            return task;
        }

        Task IAuthenticationFilter.ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            // nothing to do
            return Task.FromResult(0);
        }

        bool IFilter.AllowMultiple
        {
            get { return true; }
        }
    }

    internal class CustomizePrincile : GenericPrincipal
    {
        public CustomizePrincile(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
        }

        public override bool IsInRole(string role)
        {
            return true;
        }
    }

    internal class CustomizeIdentity : GenericIdentity
    {
        public CustomizeIdentity(GenericIdentity identity)
            : base(identity)
        {
        }

        public CustomizeIdentity(string name, string type)
            : base(name, type)
        {
        }

        public CustomizeIdentity(string name)
            : base(name)
        {
        }


        public override bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public ICollection<int> CommodityList { get; set; }
        public int UserType { get; set; }
        public int UserId { get; set; }
        public List<int> AccountList { get; set; }
        public int CorporationId { get; set; }
    }

    internal class AccessToken
    {
        private const string _key = "98744F82BA626430C8A85550";
        private int _effectiveHours;
        private int EffectiveHours
        {
            get
            {
                if (_effectiveHours < 1)
                {
                    int result;
                    if (int.TryParse(WebConfigurationManager.AppSettings["AccessTokenAlive"], System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
                    {
                        _effectiveHours = result;
                    }
                    else
                    {
                        _effectiveHours = 168;
                    }
                }
                return _effectiveHours;
            }
        }

        public static bool TryParse(string str, out AccessToken accessToken)
        {
            try
            {
                accessToken = FromString(Decrypt(str));
                return true;
            }
            catch (Exception)
            {
                accessToken = null;
                return false;
            }
        }

        private static byte[] _keyBytes;

        private static byte[] KeyBytes
        {
            get
            {
                if (_keyBytes != null) return _keyBytes;
                _keyBytes = Encoding.UTF8.GetBytes(_key);
                return _keyBytes;
            }
        }

        private static AccessToken FromString(string str)
        {
            return JsonConvert.DeserializeObject<AccessToken>(str);
        }

        private static string Decrypt(string str)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = KeyBytes;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
                var fromBytes = Convert.FromBase64String(str);
                var encryptedBytes = cryptoTransform.TransformFinalBlock(fromBytes, 0, fromBytes.Length);
                return new string(Encoding.UTF8.GetChars(encryptedBytes));
            }
        }

        private static string Encrypt(string str)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = KeyBytes;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
                var fromBytes = Encoding.UTF8.GetBytes(str);
                var encryptedBytes = cryptoTransform.TransformFinalBlock(fromBytes, 0, fromBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string CorporationId { get; set; }
        public string CommodityList { get; set; }
        public string AccountList { get; set; }
        public string UserType { get; set; }
        public string UserId { get; set; }
        public DateTime Stamp { get; set; }

        public override string ToString()
        {
            return Encrypt(this.ToJson());
        }

        public bool IsValid()
        {
            return ((DateTime.UtcNow - Stamp).TotalHours <= EffectiveHours);
        }
    }

    internal class RequestToken
    {
        private const string _key = "3DDF47928F128A5C6FF870D8";

        public static bool TryParse(string str, out RequestToken requestToken)
        {
            try
            {
                requestToken = FromString(Decrypt(str));
                return true;
            }
            catch (Exception)
            {
                requestToken = null;
                return false;
            }
        }

        private static byte[] _keyBytes;

        private static byte[] KeyBytes
        {
            get
            {
                if (_keyBytes != null) return _keyBytes;
                _keyBytes = Encoding.UTF8.GetBytes(_key);
                return _keyBytes;
            }
        }

        private static RequestToken FromString(string str)
        {
            return JsonConvert.DeserializeObject<RequestToken>(str);
        }

        private static string Decrypt(string str)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = KeyBytes;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
                var fromBytes = Convert.FromBase64String(str);
                var encryptedBytes = cryptoTransform.TransformFinalBlock(fromBytes, 0, fromBytes.Length);
                return new string(Encoding.UTF8.GetChars(encryptedBytes));
            }
        }

        private static string Encrypt(string str)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = KeyBytes;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
                var fromBytes = Encoding.UTF8.GetBytes(str);
                var encryptedBytes = cryptoTransform.TransformFinalBlock(fromBytes, 0, fromBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string ClientKey { get; set; }

        public override string ToString()
        {
            return Encrypt(this.ToJson());
        }

        public bool IsValid()
        {
            return GMK.OperationSystem.WFProxy.Infrastructure.ClientKey.Value.Equals(ClientKey, StringComparison.InvariantCulture);
        }
    }

    internal static class ClientKey
    {
        private const string _salt = "A35ECEFE-429A-4675-BE78-9815195AB6D5";

        private static string _value;

        public static string Value
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_value)) return _value;
                _value = Hash(_salt);
                return _value;
            }
        }

        private static string Hash(string v)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            return Convert.ToBase64String((sha.ComputeHash(Encoding.UTF8.GetBytes(v))));
        }

        public static bool IsValid(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            return Value.Equals(str, StringComparison.InvariantCulture);
        }
    }
}