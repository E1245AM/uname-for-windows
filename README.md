# uname for Windows

A Windows implementation of the Unix uname command.

This tool provides system information in a format similar to GNU coreutils, adapted for Windows environments.

## ✨ Features

- Supports common uname options (-a, -s, -n, -r, -v, -m, -o, etc.)

- Reads real Windows system information from:

- Registry (CurrentBuild, UBR, InstallDate)

- .NET runtime (OSArchitecture, machine name)

- Detects Windows 10 / Windows 11 based on build number

- Outputs kernel-style version strings (e.g., 10.0.22631.3085)

- Compatible with PowerShell / CMD / Git Bash / MSYS2

## 📦 Usage
uname [OPTION]...  
With no options, the default output is equivalent to -s.  
Supported Options:  
| Short | Long | Description | 
|--|--|--| 
| -a | --all | print all information | 
| -s | --kernel-name | print the kernel name |
| -n | --nodename | print the network node hostname |
| -r | --kernel-release | print the kernel release |
| -v | --kernel-version | print the kernel version |
| -m | --machine | print the machine hardware name |
| -p | --processor | print the processor type (non-portable) |
| -i | --hardware-platform | print the hardware platform (non-portable) |
| -o | --operating-system | print the operating system |
| | --help | display this help and exit |
| | --version | output version information and exit |

## 🖥️ Example Output

    C:\Users\E1245AM>uname -a
    Windows E1245AM-LAPTOP 10.0.26200.7462 #1 NT_KERNEL Windows 11 (2026-01-05) x86_64 Microsoft/Windows
    
    C:\Users\E1245AM>uname -m
    X86_64
    
    C:\Users\E1245AM>uname -r
    Windows 11

## 📜 License

This project is licensed under the GPLv3.

See the LICENSE file for details.

## 👤 Author

E1245AM

Windows version written by E1245AM .  
Originally inspired by GNU coreutils  uname.
