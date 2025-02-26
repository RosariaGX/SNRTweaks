using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class CrabsquidPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void CrabSquidStart_Prefix(Creature instance)
        {
            if (Plugin.Options.AreCrabsquidsDisabled && instance is CrabSquid crabSquid)
            {
                Object.Destroy(crabSquid.gameObject);
            }
        }
    }
}
