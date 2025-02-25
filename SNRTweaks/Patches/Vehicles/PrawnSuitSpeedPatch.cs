using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Vehicles
{
    [HarmonyPatch]
    public class PrawnSuitSpeedPatch
    {
        internal static float defaultXZSpeed;

        [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Awake)), HarmonyPostfix]
        private static void PrawnAwake_PostFix(Exosuit __instance) 
        {
            defaultXZSpeed = __instance.xzSpeed;

            __instance.xzSpeed *= Plugin.Options.prawnSpeedMultiplier;
        }

        [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Update)), HarmonyPostfix]
        private static void PrawnUpdate_PostFix()
        {
            if (Plugin.Options.wasPrawnSliderChanged) 
            {
                foreach (var prawnsuits in Object.FindObjectsOfType<Exosuit>())
                {
                    prawnsuits.xzSpeed = defaultXZSpeed;

                    prawnsuits.xzSpeed *= Plugin.Options.prawnSpeedMultiplier;
                    Plugin.Options.wasSeamothSliderChanged = false;
                }
            }
        }
    }
}
