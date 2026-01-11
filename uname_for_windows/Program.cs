using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

class WindowsUname
{
    static void Main(string[] args)
    {
        //从注册表读取Windows版本信息
        string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(key))
        {
            string buildNumber = reg.GetValue("CurrentBuild")?.ToString();
            object ubrObj = reg.GetValue("UBR"); // Update Build Revision
            int ubr = ubrObj != null ? Convert.ToInt32(ubrObj) : 0,
                build = int.TryParse(buildNumber, out int b) ? b : 0;
            // 读取Windows安装日期
            object installDateObj = reg.GetValue("InstallDate");
            if (installDateObj != null)
            {
                int timestamp = Convert.ToInt32(installDateObj);
                DateTime installDate = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
                //Console.WriteLine($"{installDate:yyyy-MM-dd}");

                // 拼接完整版本号
                string KernelVersion = $"10.0.{buildNumber}.{ubr}";

                // 判断是 Windows 10 or Windows 11
                string windowsVersion = build >= 22000 ? "Windows 11" : "Windows 10";

                // 架构查询
                string arch = RuntimeInformation.OSArchitecture switch
                {
                    Architecture.X86 => "x86",
                    Architecture.X64 => "x86_64",
                    Architecture.Arm => "arm",
                    Architecture.Arm64 => "arm64",
                    _ => RuntimeInformation.OSArchitecture.ToString()
                };

                string opt = args.Length > 0 ? args[0] : null;

                // 无参数时默认输出
                if (opt == null)
                {
                    Console.WriteLine("Windows");
                    return;
                }

                //==========分割线==========

                if (args.Length > 0 && (args[0] == "-a" || args[0] == "--all"))
                {

                    Console.WriteLine($"Windows {Environment.MachineName} {KernelVersion} #1 NT_KERNEL {windowsVersion} ({installDate:yyyy-MM-dd}) {arch} Microsoft/Windows");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-s" || args[0] == "--kernel-name"))
                {
                    Console.WriteLine("Windows");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-n" || args[0] == "--nodename"))
                {
                    Console.WriteLine($"{Environment.MachineName}");
                    return;
                }

                if (args.Length > 0 && (args[0] == "-r" || args[0] == "--kernel-release"))
                {
                    Console.WriteLine($"{windowsVersion}");
                    return;
                }

                if (args.Length > 0 && (args[0] == "-v" || args[0] == "--kernel-version"))
                {
                    Console.WriteLine($"#1 NT_KERNEL {KernelVersion} {windowsVersion} ({installDate:yyyy-MM-dd})");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-m" || args[0] == "--machine"))
                {
                    Console.WriteLine($"{arch}");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-p" || args[0] == "--processor"))
                {
                    Console.WriteLine("unknown");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-i" || args[0] == "--hardware-platform"))
                {
                    Console.WriteLine("unknown");
                    return;
                }
                if (args.Length > 0 && (args[0] == "-o" || args[0] == "--operating-system"))
                {
                    Console.WriteLine("Microsoft/Windows");
                    return;
                }
                if (args.Length > 0 && args[0] == "--help")
                {
                    Console.WriteLine("Usage: uname [OPTION]...");
                    Console.WriteLine("Print certain system information.  With no OPTION, same as -s.");
                    Console.WriteLine("");
                    Console.WriteLine("  -a, --all                print all information, in the following order,");
                    Console.WriteLine("                             except omit -p and -i if unknown:");
                    Console.WriteLine("  -s, --kernel-name        print the kernel name");
                    Console.WriteLine("  -n, --nodename           print the network node hostname");
                    Console.WriteLine("  -r, --kernel-release     print the kernel release");
                    Console.WriteLine("  -v, --kernel-version     print the kernel version");
                    Console.WriteLine("  -m, --machine            print the machine hardware name");
                    Console.WriteLine("  -p, --processor          print the processor type (non-portable)");
                    Console.WriteLine("  -i, --hardware-platform  print the hardware platform (non-portable)");
                    Console.WriteLine("  -o, --operating-system   print the operating system");
                    Console.WriteLine("      --help        display this help and exit");
                    Console.WriteLine("      --version     output version information and exit");
                    Console.WriteLine("");
                    Console.WriteLine("GNU coreutils online help: <https://www.gnu.org/software/coreutils/>");
                    Console.WriteLine("Full documentation <https://www.gnu.org/software/coreutils/uname>");
                    Console.WriteLine("or available locally via: info '(coreutils) uname invocation'");
                    return;
                }
                if (args.Length > 0 && args[0] == "--version")
                {
                    Console.WriteLine("uname for windows 0.1");
                    Console.WriteLine("Packaged by E1245AM");
                    Console.WriteLine("Copyright (C) E1245AM");
                    Console.WriteLine("License GPLv3+: GNU GPL version 3 or later <https://gnu.org/licenses/gpl.html>.");
                    Console.WriteLine("This is free software: you are free to change and redistribute it.");
                    Console.WriteLine("There is NO WARRANTY, to the extent permitted by law.");
                    Console.WriteLine("");
                    Console.WriteLine("Originally written by David MacKenzie.");
                    Console.WriteLine("Windows version written by E1245AM.");
                    return;
                }
                else
                {
                    // 不明参数处理
                    Console.WriteLine($"uname: invalid option -- '{opt}'");
                    Console.WriteLine("Try 'uname --help' for more information.");
                    return;
                }
            }

        }
    }
}
