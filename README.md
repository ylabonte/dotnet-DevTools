# My personal .NET dev tools
# <small>dotnet-DevTools</small>
This project is supposed to be a collection of more or less useful (...or useless) tools that have 
emerged and will emerge motivated by my everyday work.

I don't think these tools benefit anyone but me. If someone sees it differently and misses 
documentation, please just create an issue.

## WindowsEnvLoader
Simple Tool to open/edit flat JSON files (simple key/value pairs as in Visual Studio's user secrets)
and save the result as user environment variables.  
The tool can also be used in console mode:
```powershell
WindowsEnvLoader.exe <JSON file> [--delete] [--yes]
```

Or for more information:
```powershell
WindowsEnvLoader.exe --help
```

This is a merge of the prior Console App and Windows Desktop App (below).

## ~~EnvLoaderWindows~~
~~Windows Forms Application with a minimal User Interface to display and edit environment variables
loaded from a json file or insterted manually.~~

## ~~SetUserEnvVars~~
~~Windows Console tool for loading a flat json object from a file and setting the key/value pairs as
corresponding environment vars.~~

~~This project also acts as library for the Windows registry manipulations necessary for setting and 
unsetting user environment vars (Windows only!). As such it is a dependency of the EnvLoaderWindows 
above.~~
