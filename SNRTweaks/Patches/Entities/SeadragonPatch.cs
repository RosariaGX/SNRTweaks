using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Entities
{
    [HarmonyPatch]
    internal class SeadragonPatch
    {
        [HarmonyPatch(typeof(Creature), nameof(Creature.Start)), HarmonyPrefix]
        private static void SeadragonLeviathanStart_Prefix(Creature instance)
        {
            if (Plugin.Options.AreSeaDragonsDisabled && instance is SeaDragon seaDragon)
            {
                Object.Destroy(seaDragon.gameObject);
            }
        }
    }
}
