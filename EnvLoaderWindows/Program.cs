using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SetUserEnvVars;

namespace EnvLoaderWindows
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                return ConsoleRun(args);
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            return 0;
        }
        
        static int ConsoleRun(string[] args)
        {
            RootCommand rootCommand = new RootCommand(
                description: "Simple tool for setting user environment variables from a JSON file (eg. a user secrets file from Visual Studio)."
            ) {
                new Argument<string>(
                    name: "jsonFile",
                    description: "A JSON file that represents a simple key/value list without any nesting."
                ),
                new Option<bool>(
                    aliases: new string[]{"--delete", "-d"},
                    getDefaultValue: () => false,
                    description: "Remove given environment vars (irrespective of their values)."
                ),
                new Option<bool>(
                    aliases: new string[]{"--yes", "-y"},
                    getDefaultValue: () => false,
                    description: "Yes to all/ do not ask before adding/deleting operations."
                ),
            };

            rootCommand.Handler = CommandHandler.Create<string, bool, bool>(Program.ProcessJsonFile);

            return rootCommand.InvokeAsync(args).Result;
        }

        public static int ProcessJsonFile(string jsonFile, bool delete, bool yes)
        {
            var envVars = new Dictionary<string, object>();

            Console.WriteLine($@"Reading user environment variables from ""{jsonFile}""");
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string jsonString = reader.ReadToEnd();
                envVars = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            }

            Console.WriteLine($@"Read {envVars.Count} variables:");
            if (delete)
            {
                DeleteVariables(envVars, yes);
            } else
            {
                AddVaribles(envVars, yes);
            }

            return 0;
        }

        private static void AddVaribles(Dictionary<string, object> envVars, bool yes)
        {
            foreach (var envVar in envVars)
            {
                var keyPress = ConsoleKey.Enter;
                do
                {
                    Console.WriteLine($@"Setting user environment variable ""{envVar.Key}""");
                    Console.Write($"\tto \"{envVar.Value}\"");
                    if (yes)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.WriteLine("? [(y)es/(n)o]");
                        keyPress = Console.ReadKey(false).Key;
                    }

                    if (yes || keyPress == ConsoleKey.Y)
                        RegistryHelper.SetRegistryValue(Registry.CurrentUser, "Environment", envVar.Key, envVar.Value);

                } while (!yes && keyPress != ConsoleKey.N && keyPress != ConsoleKey.Y);
            }
        }

        private static void DeleteVariables(Dictionary<string, object> envVars, bool yes)
        {
            foreach (var envVar in envVars)
            {
                var keyPress = ConsoleKey.Enter;
                do
                {
                    Console.Write($@"Deleting user environment variable ""{envVar.Key}""");
                    if (yes)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.WriteLine("? [(y)es/(n)o]");
                        keyPress = Console.ReadKey(false).Key;
                    }

                    if (yes || keyPress == ConsoleKey.Y)
                        RegistryHelper.UnsetRegistryValue(Registry.CurrentUser, "Environment", envVar.Key);

                } while (!yes && keyPress != ConsoleKey.N && keyPress != ConsoleKey.Y);
            }
        }
    }
}