using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class WarperPatch
    {
        [HarmonyPatch(typeof(Warper), nameof(Warper.Start)), HarmonyPrefix]
        private static void WarperStart_Prefix(Warper __instance)
        {
            if (Plugin.Options.areWarpersDisabled)
            {
                GameObject.Destroy(__instance.gameObject);
            }
        }
    }
}
