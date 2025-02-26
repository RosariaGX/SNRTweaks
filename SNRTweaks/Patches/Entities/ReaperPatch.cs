using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class ReaperPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void ReaperLeviathanStart_Prefix(Creature instance)
        {
            if (Plugin.Options.AreReapersDisabled && instance is ReaperLeviathan reaper)
            {
                Object.Destroy(reaper.gameObject);
            }
        }
    }
}
