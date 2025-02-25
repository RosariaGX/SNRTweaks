using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Vehicles
{
    [HarmonyPatch]
    public class SeamothSpeedPatch
    {
        internal static float defaultForwardForce;

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Awake)), HarmonyPostfix]
        private static void SeamothAwake_PostFix(SeaMoth __instance) 
        {
            defaultForwardForce = __instance.forwardForce;

            __instance.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
        }

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Update)), HarmonyPostfix]
        private static void SeamothUpdate_PostFix()
        {
            if (Plugin.Options.wasSeamothSliderChanged) 
            {
                foreach (var seamoths in Object.FindObjectsOfType<SeaMoth>())
                {
                    seamoths.forwardForce = defaultForwardForce;

                    seamoths.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
                    Plugin.Options.wasSeamothSliderChanged = false;
                }
            }
        }
    }
}
