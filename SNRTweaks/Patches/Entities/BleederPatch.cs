using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class BleederPatch
    {
        [HarmonyPatch(typeof(Bleeder), nameof(Bleeder.Start)), HarmonyPrefix]
        private static void BleederStart_Prefix(Bleeder instance)
        {
            if (Plugin.Options.AreBleedersDisabled)
            {
                Object.Destroy(instance.gameObject);
            }
        }
    }
}
