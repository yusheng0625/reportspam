using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamReporter
{
    class Filters
    {
        public List<string> m_blackMailList = new List<string>();
        public List<string> m_blackDomainList = new List<string>();
        public Filters()
        {
            //m_blackMailList.Add("realtor.com");
            //m_blackMailList.Add("alerts@email.skype.com");
        }

        public void clear()
        {
            m_blackMailList.Clear();
            m_blackDomainList.Clear();
        }
        public void init(filterData data)
        {
            m_blackMailList.Clear();
            m_blackDomainList.Clear();

            foreach(string strval in data.emails)
            {
                string strVal = strval.Trim();
                if (strVal == "") continue;
                m_blackMailList.Add(strVal);
            }
            foreach (string strval in data.domains)
            {
                string strVal = strval.Trim();
                if (strVal == "") continue;
                m_blackDomainList.Add(strVal);
            }
        }

        public bool isBlackDomain(string strMail)
        {
            string strVal = strMail.ToLower();
            string[] data = strVal.Split('@');
            if (data.Length < 2) return false;

            foreach (string strBlackDomain in m_blackDomainList)
            {
                if (strBlackDomain == data[1])
                    return true;
            }
            return false;            
        }

        public bool isBlackMail(string strMail)
        {
            string strVal = strMail.ToLower();
            foreach (string strBlackMail in m_blackMailList)
            {
                if (strBlackMail == strVal)
                    return true;
            }
            return false;
        }
    }
}
