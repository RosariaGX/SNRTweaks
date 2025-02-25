using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    public class SeadragonPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void SeadragonLeviathanStart_Prefix(Creature __instance)
        {
            if (Plugin.Options.areSeaDragonsDisabled && __instance is SeaDragon seaDragon)
            {
                GameObject.Destroy(seaDragon.gameObject);
            }
        }
    }
}
