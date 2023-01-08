using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkTools
{
    class Validator
    {
        public static bool ValidateAddressFormat(string address)
        {
            if (address == null)
            {
                return false;
            }

            string[] parts = address.Split('.');

            if (parts.Length != 4)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if (Convert.ToInt32(parts[i]) > 255)
                {
                    return false;
                }
            }

            byte addressBytes;
            
            return parts.All(part => byte.TryParse(part, out addressBytes));
        }
    }
}