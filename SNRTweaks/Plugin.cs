using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using SNRTweaks.Config;

namespace SNRTweaks;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class Plugin : BaseUnityPlugin
{
    public new static ManualLogSource Logger { get; private set; }
    
    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

    internal static MenuOptions Options { get; } = OptionsPanelHandler.RegisterModOptions<MenuOptions>();

    public void Awake()
    {

        // set project-scoped logger instance
        Logger = base.Logger;

        // register harmony patches, if there are any
        Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
}