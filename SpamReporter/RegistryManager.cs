using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SpamReporter
{
    class RegistryManager
    {
        public static string GetValue(RegistryKey v_key, string v_subkey, string v_name)
        {
            string strRet = "";
            RegistryKey t_regkey = v_key.OpenSubKey(v_subkey);
            if (t_regkey != null)
            {
                strRet = (string)t_regkey.GetValue(v_name);
                t_regkey.Close();
            }
            return strRet;
        }

        public static void SetValue(RegistryKey v_key, string v_subkey, string v_name, string v_value)
        {
            RegistryKey t_regkey = v_key.CreateSubKey(v_subkey);
            if (t_regkey == null) return;

            t_regkey.SetValue(v_name, v_value);
            t_regkey.Close();
        }

    }
}
