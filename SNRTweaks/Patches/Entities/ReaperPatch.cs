using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class ReaperPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void ReaperLeviathanStart_Prefix(Creature __instance)
        {
            if (Plugin.Options.areReapersDisabled && __instance is ReaperLeviathan reaper)
            {
                GameObject.Destroy(reaper.gameObject);
            }
        }
    }
}
