using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsEnvLoader;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static int Main(string[] args)
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

    private static int ConsoleRun(string[] args)
    {
        var rootCommand = new RootCommand(
            description: ProgramResources.ProgramDescription
        );
        var jsonFileArg = new Argument<string>(
            name: "jsonFile",
            description: ProgramResources.ProgramArgJsonFile
        );
        rootCommand.AddArgument(jsonFileArg);
        var deleteOpt = new Option<bool>(
            aliases: ["--delete", "-d"],
            getDefaultValue: () => false,
            description: ProgramResources.ProgramOptDelete
        );
        rootCommand.AddOption(deleteOpt);
        var yesOpt = new Option<bool>(
            aliases: ["--yes", "-y"],
            getDefaultValue: () => false,
            description: ProgramResources.ProgramOptYes
        );
        rootCommand.AddOption(yesOpt);
        rootCommand.SetHandler(
            (json, delete, yes) => ProcessJsonFile(json, delete, yes), 
            jsonFileArg, 
            deleteOpt, 
            yesOpt);

        return rootCommand.Invoke(args);
    }

    private static int ProcessJsonFile(string jsonFile, bool delete, bool yes)
    {
        Dictionary<string, object>? envVars;

        Console.WriteLine(ProgramResources.ReadingUserEnvVarsFrom, jsonFile);
        using (var reader = new StreamReader(jsonFile))
        {
            try
            {
                var jsonString = reader.ReadToEnd();
                envVars = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(ProgramResources.GotNoJson);
                return 1;
            }
            catch (JsonException e)
            {
                Console.WriteLine(ProgramResources.JsonParseError, e.Message);
                return 1;
            }
        }
        
        if (envVars == null || envVars.Count < 1)
        {
            Console.WriteLine(ProgramResources.GotEmptyJson);
            return 0;
        }

        Console.WriteLine(ProgramResources.ReadNumVariables, envVars.Count);
        if (delete)
        {
            DeleteVariables(envVars, yes);
        } 
        else
        {
            AddVariables(envVars, yes);
        }

        return 0;
    }

    private static void AddVariables(Dictionary<string, object>? envVars, bool yes)
    {
        if (envVars == null) return;
        foreach (var envVar in envVars)
        {
            var keyPress = ConsoleKey.Enter;
            do
            {
                Console.Write(ProgramResources.SettingUserEnvVar, envVar.Key, envVar.Value);
                if (yes)
                {
                    Console.WriteLine('.');
                }
                else
                {
                    Console.WriteLine(ProgramResources.QuestionYesNo);
                    keyPress = Console.ReadKey(false).Key;
                }

                if (yes || keyPress == ConsoleKey.Y)
                {
                    RegistryHelper.SetRegistryValue(Registry.CurrentUser, "Environment", envVar.Key, envVar.Value);
                }
            } while (!yes && keyPress != ConsoleKey.N && keyPress != ConsoleKey.Y);
        }
    }

    private static void DeleteVariables(Dictionary<string, object>? envVars, bool yes)
    {
        if (envVars == null) return;
        foreach (var envVar in envVars)
        {
            var keyPress = ConsoleKey.Enter;
            do
            {
                Console.Write(ProgramResources.DeletingUserEnvVar, envVar.Key);
                if (yes)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.WriteLine(ProgramResources.QuestionYesNo);
                    keyPress = Console.ReadKey(false).Key;
                }

                if (yes || keyPress == ConsoleKey.Y)
                {
                    RegistryHelper.UnsetRegistryValue(Registry.CurrentUser, "Environment", envVar.Key);
                }
            } while (!yes && keyPress != ConsoleKey.N && keyPress != ConsoleKey.Y);
        }
    }
}
