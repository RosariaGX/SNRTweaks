using HarmonyLib;
using UnityEngine;

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
            }
        }
    }
}
