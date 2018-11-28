﻿using Harmony;
using System;
using System.Diagnostics;
using System.Reflection;

namespace PulsarPluginLoader.hooks
{
    [HarmonyPatch(typeof(PLNetworkManager))]
    [HarmonyPatch("Start")]
    class GameVersion
    {
        static void Postfix(PLNetworkManager __instance)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);

            __instance.VersionString += $"\nPPL {fvi.FileVersion}";
        }

    }
}
