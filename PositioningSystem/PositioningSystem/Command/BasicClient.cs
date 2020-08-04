using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PositioningSystem.Command
{
    public class BasicClient
    {
        public string SendRequest(string url, string method, string auth, string reqParams)
        {
            //这是发送Http请求的函数，可根据自己内部的写法改造
            HttpWebRequest myReq = null;
            HttpWebResponse response = null;
            string result = string.Empty;
            try
            {
                myReq = (HttpWebRequest)WebRequest.Create(url);
                myReq.Method = method;
                myReq.ContentType = "application/json;";
                myReq.KeepAlive = false;

                //basic 验证下面这句话不能少
                if (!String.IsNullOrEmpty(auth))
                {
                    myReq.Headers.Add("Authorization", "Basic " + auth);
                }

                if (method == "POST" || method == "PUT")
                {
                    byte[] bs = Encoding.UTF8.GetBytes(reqParams);
                    myReq.ContentLength = bs.Length;
                    using (Stream reqStream = myReq.GetRequestStream())
                    {
                        reqStream.Write(bs, 0, bs.Length);
                        reqStream.Close();
                    }
                }

                response = (HttpWebResponse)myReq.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (Equals(response.StatusCode, HttpStatusCode.OK))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpStatusCode errorCode = ((HttpWebResponse)e.Response).StatusCode;
                    string statusDescription = ((HttpWebResponse)e.Response).StatusDescription;
                    using (StreamReader sr = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream(), Encoding.UTF8))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                else
                {
                    result = e.Message;
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (myReq != null)
                {
                    myReq.Abort();
                }
            }

            return result;
        }

        public string sendHttpRequest(string url, string reqparam, string method = "POST")
        {
            string auth = Base64Encode("key:secret");
            return SendRequest(url, method, auth, reqparam);
        }

        private string Base64Encode(string value)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}
