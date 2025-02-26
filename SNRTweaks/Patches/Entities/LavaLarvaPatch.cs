using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class LavaLarvaPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void LarvaStart_Prefix(Creature instance)
        {
            if (Plugin.Options.AreLarvaDisabled && instance is LavaLarva larva)
            {
                Object.Destroy(larva.gameObject);
            }
        }
    }
}
