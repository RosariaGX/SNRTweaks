using HarmonyLib;
using Nautilus.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class BleederPatch
    {
        [HarmonyPatch(typeof(Bleeder), nameof(Bleeder.Start)), HarmonyPrefix]
        private static void BleederStart_Prefix(Bleeder __instance)
        {
            if (Plugin.Options.areBleedersDisabled)
            {
                GameObject.Destroy(__instance.gameObject);
                Plugin.Logger.LogInfo("Bleeder was destroyed");
            }
        }
    }
}
