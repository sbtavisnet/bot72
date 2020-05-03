using System;
using System.Net;

namespace Bot72.Domain.Utils
{
    public class AvisnetUtils
    {

        static public string OnlyNumber(string value)
        {
            return String.Join("", System.Text.RegularExpressions.Regex.Split(value, @"[^\d]"));
        }

        static public int GetSize(string value)
        {
            return value.Length;
        }

        static public bool IsConnected()
        {
            HttpWebRequest req;
            HttpWebResponse resp;

            try
            {
                req = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");
                resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                
            }
        }    



       
    }
}
