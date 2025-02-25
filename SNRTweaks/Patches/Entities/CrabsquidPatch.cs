using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class CrabsquidPatch
    {
        [HarmonyPatch(typeof(CrabSquid), nameof(CrabSquid.Start)), HarmonyPrefix]
        private static void CrabSquidStart_Prefix(CrabSquid __instance)
        {
            if (Plugin.Options.areCrabsquidsDisabled)
            {
                GameObject.Destroy(__instance.gameObject);
            }
        }
    }
}
