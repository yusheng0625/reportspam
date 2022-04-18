using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SpamReporter
{
    public class filterData
    {
        public IEnumerable<string> emails { get; set; }
        public IEnumerable<string> domains { get; set; }
    }

    class IWebService
    {
        WebQuery _query = new WebQuery();
        public filterData getFilterData()
        {
            filterData data = null;
            try
            {
                string strJson = _query.GetSource("https://spamreport.com.au/wp-json/outlook/v2/getFilter", 1);
                data = JsonConvert.DeserializeObject<filterData>(strJson);
            }
            catch (Exception ee)
            {

            }
            return data;
        }

        public bool postSpamReport(string sender, string subject, string content, string receiver, string reason)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("sender", sender);
            dict.Add("subject", subject);
            dict.Add("content", content);
            dict.Add("receiver", receiver);
            dict.Add("reason", reason);
            string strRet = _query.GetMultipartPost("https://spamreport.com.au/wp-json/outlook/v2/reportSpam", dict);
            if(strRet== "success")
                return true;
            return false;
        }

        public bool postNewSpamReport(string sender, string subject, string content, string receiver)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("sender", sender);
            dict.Add("subject", subject);
            dict.Add("content", content);
            dict.Add("receiver", receiver);
            string strRet = _query.GetMultipartPost("https://spamreport.com.au/wp-json/outlook/v2/reportNewSpam", dict);
            if (strRet == "success")
                return true;
            return false;
        }

    }
}
