using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class WarperPatch
    {
        [HarmonyPatch(typeof(WarperSpawner), nameof(WarperSpawner.OnEnable)), HarmonyPrefix]
        private static void WarperSpawnerOnEnabled_Prefix(WarperSpawner __instance)
        {
            if (Plugin.Options.areWarpersDisabled)
            {
                GameObject.Destroy(__instance.gameObject);
            }
        }
    }
}
