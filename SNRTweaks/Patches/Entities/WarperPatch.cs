using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class WarperPatch
    {
        [HarmonyPatch(typeof(WarperSpawner), nameof(WarperSpawner.OnEnable)), HarmonyPrefix]
        private static void WarperSpawnerOnEnabled_Prefix(WarperSpawner instance)
        {
            if (Plugin.Options.AreWarpersDisabled)
            {
                Object.Destroy(instance.gameObject);
            }
        }
    }
}
