namespace networkTools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any(arg => arg == "--help"))
            {
                Console.WriteLine("List of usable flags: \n--ipAddress              Prints the Ip Address\n--subnetMask             Prints the Subnet Mask\n--ipBits                 Prints the Ip Address in Binary\n--smBits                 Prints the Subnet Mask in Binary\n--networkAddress         Prints the Network Address\n--broadcastAddress       Prints the Broadcast Address\n--wildcardMask           Prints the Wildcard Mask\n--numberOfHosts          Prints the Number of Hosts\n--numberOfUsableHosts    Prints the Number of Usable Hosts\n--firstUsableHost        Prints the First Usable Host's Ip Address\n--lastUsableHost         Prints the Last Usable Host's Ip Address\n--hostsRange             Prints the Range of Usable Hosts\n--addressClass           Prints the Class of the Ip Address\n--all                    Prints everything");
                return;
            }
            if (args.Length <= 2)
            {
                Console.WriteLine("Command usage: networkTools <ip address> <subnet mask> (flags) \nUse --help to display a list of flags");
                return;
            }

            Ip ip = new Ip();

            if (!ip.SetIpAddress(args[0].ToString()))
            {
                Console.WriteLine(args[0] + " is not a valid ip address");
                return;
            }

            if (!ip.SetSubnetMask(args[1].ToString()))
            {
                Console.WriteLine(args[1] + " is not a valid subnet mask");
                return;
            }


            string[] allFlags = { "--ipAddress", "--subnetMask", "--ipBits", "--smBits", "--networkAddress", "--broadcastAddress", "--wildcardMask", "--numberOfHosts", "--numberOfUsableHosts", "--firstUsableHost", "--lastUsableHost", "--hostsRange", "--addressClass" };
            string[] flags = new string[args.Length - 2];

            if (args.Any(arg => arg == "--all"))
            {
                flags = allFlags;
            }
            else
            {
                for (int i = 0; i < args.Length - 2; i++)
                {
                    if (allFlags.Any(flag => flag == args[i + 2]))
                    {
                        flags[i] = args[i + 2];
                    }
                    else
                    {
                        Console.WriteLine(args[i + 2] + " is not a valid flag");
                        return;
                    }
                }
            }

            for (int i = 0; i < flags.Length; i++)
            {
                switch (flags[i])
                {
                    case "--ipAddress":
                        Console.WriteLine("Ip Address: " + ip.GetIpAddress());
                        break;
                    case "--subnetMask":
                        Console.WriteLine("Mask: " + ip.GetSubnetMask());
                        break;
                    case "--ipBits":
                        Console.WriteLine("Ip Bits: " + ip.GetIpBits());
                        break;
                    case "--smBits":
                        Console.WriteLine("Mask Bits: " + ip.GetSmBits());
                        break;
                    case "--networkAddress":
                        Console.WriteLine("Network Address: " + ip.GetNetworkAddress());
                        break;
                    case "--broadcastAddress":
                        Console.WriteLine("Broadcast Address: " + ip.GetBroadcastAddress());
                        break;
                    case "--wildcardMask":
                        Console.WriteLine("Wildcard Mask: " + ip.GetWildcardMask());
                        break;
                    case "--numberOfHosts":
                        Console.WriteLine("Number of Hosts: " + ip.GetNumberOfHosts());
                        break;
                    case "--numberOfUsableHosts":
                        Console.WriteLine("Number of Usable Hosts: " + ip.GetNumberOfUsableHosts());
                        break;
                    case "--firstUsableHost":
                        Console.WriteLine("First Usable Host: " + ip.GetFirstUsableHost());
                        break;
                    case "--lastUsableHost":
                        Console.WriteLine("Last Usable Host: " + ip.GetLastUsableHost());
                        break;
                    case "--hostsRange":
                        Console.WriteLine("Hosts Range: " + ip.GetHostsRange());
                        break;
                    case "--addressClass":
                        Console.WriteLine("Address Class: " + ip.GetAddressClass());
                        break;
                }
            }

        }
    }
}