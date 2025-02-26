using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class GhostLeviathansPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void GhostLeviathanStart_Prefix(Creature instance)
        {
            if (Plugin.Options.AreGhostLeviathansDisabled && instance is GhostLeviathan ghostLeviathan)
            {
                Object.Destroy(ghostLeviathan.gameObject);
            }
        }
    }
}
