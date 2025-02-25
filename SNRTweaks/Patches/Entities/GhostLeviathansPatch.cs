using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class GhostLeviathansPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void GhostLeviathanStart_Prefix(Creature __instance)
        {
            if (Plugin.Options.areGhostLeviathansDisabled && __instance is GhostLeviathan ghostLeviathan)
            {
                GameObject.Destroy(ghostLeviathan.gameObject);
            }
        }
    }
}
