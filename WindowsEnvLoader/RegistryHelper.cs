using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace WindowsEnvLoader;

public static class RegistryHelper
{
    /// <summary>
    /// Open a registry key.
    /// </summary>
    /// <param name="baseKey">Registry base/root key (eg. <c>RegistryKey.CurrentUser</c>).</param>
    /// <param name="registryPath">Registry key as sub path to the given root (eg. <c>@"Software\Adobe\Adobe Acrobat\DC\Privileged"</c>).</param>
    /// <param name="permissionCheck">optional <c>RegistryKeyPermissionCheck</c> value.</param>
    /// <returns></returns>
    public static RegistryKey Open(RegistryKey baseKey, string registryPath,
        RegistryKeyPermissionCheck permissionCheck = RegistryKeyPermissionCheck.ReadWriteSubTree)
    {
        var key = baseKey;
        var pathParts = new Queue<string?>(registryPath.Split('\\'));
        while (pathParts.TryDequeue(out var keyName))
        {
            if (keyName == null) continue;
            key = baseKey.OpenSubKey(keyName, permissionCheck);
            if (key == null)
                throw new InvalidRegistryPathException(
                    $"""Invalid registry key: sub key "{keyName}" does not exist.""");
        }

        return key;
    }

    /// <summary>
    /// Overwrite or set a new registry value.
    /// </summary>
    /// <param name="root">Registry base/root key (eg. <c>RegistryKey.CurrentUser</c>).</param>
    /// <param name="registryPath">Registry key as sub path to the given root (eg. <c>@"Software\Adobe\Adobe Acrobat\DC\Privileged"</c>).</param>
    /// <param name="registryValueName">The registry value name (eg. <c>"bProtectedMode"</c>).</param>
    /// <param name="value">The actual value to be set.</param>
    /// <returns>The initial value, in case there was one.</returns>
    public static object? SetRegistryValue(RegistryKey root, string registryPath, string registryValueName,
        object value)
    {
        object? initialValue = null;

        try
        {
            var registryPathKey = Open(root, registryPath);
            try
            {
                initialValue = registryPathKey.GetValue(registryValueName);
            }
            catch
            {
                // ignored
            }

            registryPathKey.SetValue(registryValueName, value);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to " + (initialValue == null ? "set new" : "overwrite") +
                                $""" registry value ("{registryValueName}").""", e);
        }

        return initialValue;
    }

    /// <summary>
    /// Remove the given registry value.
    /// </summary>
    /// <param name="root">Registry base/root key (eg. <c>Microsoft.Win32.RegistryKey.CurrentUser</c>).</param>
    /// <param name="registryPath">Registry key as sub path to the given root (eg. <c>@"Software\Adobe\Adobe Acrobat\DC\Privileged"</c>).</param>
    /// <param name="registryValueName">Registry value name (eg. <c>"bProtectedMode"</c>).</param>
    public static void UnsetRegistryValue(RegistryKey root, string registryPath, string registryValueName)
    {
        try
        {
            var registryKey = Open(root, registryPath);
            registryKey.DeleteValue(registryValueName);
        }
        catch (Exception e)
        {
            throw new Exception($"""Unable to remove registry value ("{registryValueName}").""", e);
        }
    }
}

public class InvalidRegistryPathException(string? message, Exception? innerException = null)
    : Exception(message, innerException);