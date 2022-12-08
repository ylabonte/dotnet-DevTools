[![.NET Desktop Build](https://github.com/ylabonte/dotnet-DevTools/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/ylabonte/dotnet-DevTools/actions/workflows/dotnet-desktop.yml)

# My personal .NET dev tools
This project is supposed to be a collection of more or less useful (...or useless) tools that have 
emerged and will emerge motivated by my everyday work.

I don't think these tools benefit anyone but me. If someone sees it differently and misses 
documentation, please just create an issue.

## EnvLoaderWindows
Windows Forms Application with a minimal User Interface to display and edit environment variables
loaded from a json file or inserted manually.

## SetUserEnvVars
Windows Console tool for loading a flat json object from a file and setting the key/value pairs as
corresponding environment vars. 

This project also acts as library for the Windows registry manipulations necessary for setting and 
unsetting user environment vars (Windows only!). As such it is a dependency of the EnvLoaderWindows 
above.
