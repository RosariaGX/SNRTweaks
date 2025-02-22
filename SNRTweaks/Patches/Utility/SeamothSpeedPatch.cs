using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeamothSpeedPatch
    {
        internal static float defaultForwardForce;
        internal static float defaultBackwardsForce;
        internal static float defaultSidewaysForce;
        internal static float defaultVerticalForce;

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Awake)), HarmonyPostfix]
        private static void SeamothAwake_PostFix(SeaMoth __instance) 
        {
            defaultForwardForce = __instance.forwardForce;
            defaultBackwardsForce = __instance.backwardForce;
            defaultSidewaysForce = __instance.sidewardForce;
            defaultVerticalForce = __instance.verticalForce;

            __instance.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
            __instance.backwardForce *= Plugin.Options.seamothSpeedMultiplier;
            __instance.sidewardForce *= Plugin.Options.seamothSpeedMultiplier;
            __instance.verticalForce *= Plugin.Options.seamothSpeedMultiplier;
        }

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Update)), HarmonyPostfix]
        private static void SeamothUpdate_PostFix()
        {
            if (Plugin.Options.wasSeamothSliderChanged.Equals(true)) 
            {
                foreach (var seamoths in GameObject.FindObjectsOfType<SeaMoth>())
                {
                    ResetSeamothValues(seamoths);

                    seamoths.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
                    seamoths.backwardForce *= Plugin.Options.seamothSpeedMultiplier;
                    seamoths.sidewardForce *= Plugin.Options.seamothSpeedMultiplier;
                    seamoths.verticalForce *= Plugin.Options.seamothSpeedMultiplier;
                    Plugin.Logger.LogInfo($"Updated Seamoth Speed: {Plugin.Options.seamothSpeedMultiplier}");
                    Plugin.Options.wasSeamothSliderChanged = false;
                }
            }
        }

        private static void ResetSeamothValues(SeaMoth __instance)
        {
            __instance.forwardForce = defaultForwardForce;
            __instance.backwardForce = defaultBackwardsForce;
            __instance.sidewardForce = defaultSidewaysForce;
            __instance.verticalForce = defaultVerticalForce;
        }
    }
}
