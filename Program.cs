namespace networkTools {
    class Program {
        static void Main(string[] args) {
            
            if(args.Length < 2) {
                Console.WriteLine("Command usage: networkTools <ip address> <subnet mask> (flags)");
                return;
            }

            Ip ip = new Ip();

            if(!ip.SetIpAddress(args[0].ToString())){
                Console.WriteLine(args[0] + " is not a valid ip address");
                return;
            }

            if(!ip.SetSubnetMask(args[1].ToString())){
                Console.WriteLine(args[1] + " is not a valid subnet mask");
                return;
            }

            if(args.Length > 2){
                if(args.Any(arg => arg == "--ipAddress")){
                    Console.WriteLine("Ip Address: " + ip.GetIpAddress());
                }
                if(args.Any(arg => arg == "--subnetMask")){
                    Console.WriteLine("Mask: " + ip.GetSubnetMask());
                }
                if(args.Any(arg => arg == "--ipBits")){
                    Console.WriteLine("Ip Bits: " + ip.GetIpBits());
                }
                if(args.Any(arg => arg == "--smBits")){
                    Console.WriteLine("Mask Bits: " + ip.GetSmBits());
                }
                if(args.Any(arg => arg == "--networkAddress")){
                    Console.WriteLine("Network Address: " + ip.GetNetworkAddress());
                }
                if(args.Any(arg => arg == "--broadcastAddress")){
                    Console.WriteLine("Broadcast Address: " + ip.GetBroadcastAddress());
                }
                if(args.Any(arg => arg == "--wildcardMask")){
                    Console.WriteLine("Wildcard Mask: " + ip.GetWildcardMask());
                }
                if(args.Any(arg => arg == "--numberOfHosts")){
                    Console.WriteLine("Number of Hosts: " + ip.GetNumberOfHosts());
                }
                if(args.Any(arg => arg == "--numberOfUsableHosts")){
                    Console.WriteLine("Number of Usable Hosts: " + ip.GetNumberOfUsableHosts());
                }
                if(args.Any(arg => arg == "--firstUsableHost")){
                    Console.WriteLine("First Usable Host: " + ip.GetFirstUsableHost());
                }
                if(args.Any(arg => arg == "--lastUsableHost")){
                    Console.WriteLine("Last Usable Host: " + ip.GetLastUsableHost());
                }
                if(args.Any(arg => arg == "--hostsRange")){
                    Console.WriteLine("Hosts Range: " + ip.GetHostsRange());
                }
                if(args.Any(arg => arg == "--addressClass")){
                    Console.WriteLine("Address Class: " + ip.GetAddressClass());
                }
                if(args.Any(arg => arg == "--all")){
                    Console.WriteLine("Ip Address: " + ip.GetIpAddress());
                    Console.WriteLine("Mask: " + ip.GetSubnetMask());
                    Console.WriteLine("Ip Bits: " + ip.GetIpBits());
                    Console.WriteLine("Mask Bits: " + ip.GetSmBits());
                    Console.WriteLine("Network Address: " + ip.GetNetworkAddress());
                    Console.WriteLine("Broadcast Address: " + ip.GetBroadcastAddress());
                    Console.WriteLine("Wildcard Mask: " + ip.GetWildcardMask());
                    Console.WriteLine("Number of Hosts: " + ip.GetNumberOfHosts());
                    Console.WriteLine("Number of Usable Hosts: " + ip.GetNumberOfUsableHosts());
                    Console.WriteLine("First Usable Host: " + ip.GetFirstUsableHost());
                    Console.WriteLine("Last Usable Host: " + ip.GetLastUsableHost());
                    Console.WriteLine("Hosts Range: " + ip.GetHostsRange());
                    Console.WriteLine("Address Class: " + ip.GetAddressClass());
                }
            }else{
                Console.WriteLine("No flags specified. Check the readme file for a list of usable flags.");
            }
        }
    }
}