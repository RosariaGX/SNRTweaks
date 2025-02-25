using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class ReaperPatch
    {
        [HarmonyPatch(typeof(ReaperLeviathan), nameof(ReaperLeviathan.Start)), HarmonyPrefix]
        private static void ReaperLeviathanStart_Prefix(Warper __instance)
        {
            if (Plugin.Options.areReapersDisabled)
            {
                GameObject.Destroy(__instance.gameObject);
            }
        }
    }
}
