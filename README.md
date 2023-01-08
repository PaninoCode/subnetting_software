# Ip Address Tools

A command line utility to get useful information about an IP Address and Subnet Mask combo.

## Usage

    $ networkTools <ip address> <subnet mask> (flags)

## Flags

    --ipAddress              Prints the Ip Address
    --subnetMask             Prints the Subnet Mask
    --ipBits                 Prints the Ip Address in Binary
    --smBits                 Prints the Subnet Mask in Binary
    --networkAddress         Prints the Network Address
    --broadcastAddress       Prints the Broadcast Address
    --wildcardMask           Prints the Wildcard Mask
    --numberOfHosts          Prints the Number of Hosts
    --numberOfUsableHosts    Prints the Number of Usable Hosts
    --firstUsableHost        Prints the First Usable Host's Ip Address
    --lastUsableHost         Prints the Last Usable Host's Ip Address
    --hostsRange             Prints the Range of Usable Hosts
    --addressClass           Prints the Class of the Ip Address
    --all                    Prints everything

## Example

    $ networkTools 192.168.1.2 255.255.255.0 --ipAddress --smBits
                                                --wildcardMask --hostsRange

        Ip Address: 192.168.1.2
        Mask Bits: 11111111111111111111111100000000
        Wildcard Mask: 0.0.0.255
        Hosts Range: 192.168.1.1 - 192.168.1.254