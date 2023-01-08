using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkTools
{
    class Ip
    {

        private byte[] ipAddress = new byte[4];
        private byte[] subnetMask = new byte[4];

        public Ip(){
        }

        public bool SetIpAddress(string ipAddress)
        {
            if(!Validator.ValidateAddressFormat(ipAddress)) return false;

            this.ipAddress = ipAddress.Split('.').Select(byte.Parse).ToArray();
            return true;
        }

        public bool SetSubnetMask(string subnetMask)
        {
            if(!Validator.ValidateAddressFormat(subnetMask)) return false;

            this.subnetMask = subnetMask.Split('.').Select(byte.Parse).ToArray();
            return true;
        }

        public string GetIpAddress()
        {
            return this.ipAddress[0] + "." + this.ipAddress[1] + "." + this.ipAddress[2] + "." + this.ipAddress[3];
        }

        public string GetSubnetMask()
        {
            return this.subnetMask[0] + "." + this.subnetMask[1] + "." + this.subnetMask[2] + "." + this.subnetMask[3];
        }

        public string GetIpBits()
        {
            string ipBits = "";
            for(int i = 0; i < 4; i++){
                ipBits += Convert.ToString(this.ipAddress[i], 2).PadLeft(8, '0');
            }
            return ipBits;
        }

        public string GetSmBits()
        {
            string smBits = "";
            for(int i = 0; i < 4; i++){
                smBits += Convert.ToString(this.subnetMask[i], 2).PadLeft(8, '0');
            }
            return smBits;
        }

        public string GetNetworkAddress()
        {
            string networkAddress = "";
            for(int i = 0; i < 4; i++){
                networkAddress += (this.ipAddress[i] & this.subnetMask[i]) + ".";
            }
            return networkAddress.Substring(0, networkAddress.Length - 1);
        }

        public string GetBroadcastAddress()
        {
            string broadcastAddress = "";
            for(int i = 0; i < 4; i++){
                broadcastAddress += ((this.ipAddress[i] & this.subnetMask[i]) | (255 - this.subnetMask[i])) + ".";
            }
            return broadcastAddress.Substring(0, broadcastAddress.Length - 1);
        }

        public string GetWildcardMask(){
            string wildcardMask = "";
            for(int i = 0; i < 4; i++){
                wildcardMask += (255 - this.subnetMask[i]) + ".";
            }
            return wildcardMask.Substring(0, wildcardMask.Length - 1);
        }

        public string GetNumberOfHosts()
        {
            string smBits = GetSmBits();
            int numberOfHosts = 0;
            for(int i = 0; i < smBits.Length; i++){
                if(smBits[i] == '0') numberOfHosts++;
            }
            return (Math.Pow(2, numberOfHosts)).ToString();
        }

        public string GetNumberOfUsableHosts()
        {
            string smBits = GetSmBits();
            int numberOfHosts = 0;
            for(int i = 0; i < smBits.Length; i++){
                if(smBits[i] == '0') numberOfHosts++;
            }
            return (Math.Pow(2, numberOfHosts) - 2).ToString();
        }

        public string GetFirstUsableHost()
        {
            string networkAddress = GetNetworkAddress();
            string[] parts = networkAddress.Split('.');
            int lastPart = Convert.ToInt32(parts[3]);
            lastPart++;
            return parts[0] + "." + parts[1] + "." + parts[2] + "." + lastPart;
        }

        public string GetLastUsableHost()
        {
            string broadcastAddress = GetBroadcastAddress();
            string[] parts = broadcastAddress.Split('.');
            int lastPart = Convert.ToInt32(parts[3]);
            lastPart--;
            return parts[0] + "." + parts[1] + "." + parts[2] + "." + lastPart;
        }

        public string GetHostsRange(){
            return GetFirstUsableHost() + " - " + GetLastUsableHost();
        }

        public string GetAddressClass(){
            string networkAddress = GetNetworkAddress();
            string[] parts = networkAddress.Split('.');
            int firstPart = Convert.ToInt32(parts[0]);
            if(firstPart >= 1 && firstPart <= 126) return "A";
            if(firstPart >= 128 && firstPart <= 191) return "B";
            if(firstPart >= 192 && firstPart <= 223) return "C";
            if(firstPart >= 224 && firstPart <= 239) return "D";
            if(firstPart >= 240 && firstPart <= 255) return "E";
            return "Unknown";
        }
    }
}