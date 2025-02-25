using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class CrabsquidPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void CrabSquidStart_Prefix(Creature __instance)
        {
            if (Plugin.Options.areCrabsquidsDisabled && __instance is CrabSquid crabSquid)
            {
                GameObject.Destroy(crabSquid.gameObject);
            }
        }
    }
}
