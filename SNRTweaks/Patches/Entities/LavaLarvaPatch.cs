using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class LavaLarvaPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void LarvaStart_Prefix(Creature __instance)
        {
            if (Plugin.Options.areLarvaDisabled && __instance is LavaLarva larva)
            {
                GameObject.Destroy(larva.gameObject);
            }
        }
    }
}
