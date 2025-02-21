using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeamothSpeedPatch
    {
        private static float defaultForwardForce;
        private static float defaultBackwardsForce;
        private static float defaultSidewaysForce;
        private static float defaultVerticalForce;

        [HarmonyPatch(typeof(Vehicle), nameof(Vehicle.Awake)), HarmonyPostfix]
        private static void SeamothAwake_PostFix(Vehicle __instance) 
        {
            if (__instance is SeaMoth seamoth)
            {
                defaultForwardForce = seamoth.forwardForce;
                defaultBackwardsForce = seamoth.backwardForce;
                defaultSidewaysForce = seamoth.sidewardForce;
                defaultVerticalForce = seamoth.verticalForce;

                seamoth.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.backwardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.sidewardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.verticalForce *= Plugin.Options.seamothSpeedMultiplier;
            }
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

        private static void ResetSeamothValues(SeaMoth seamoth)
        {
            seamoth.forwardForce = defaultForwardForce;
            seamoth.backwardForce = defaultBackwardsForce;
            seamoth.sidewardForce = defaultSidewaysForce;
            seamoth.verticalForce = defaultVerticalForce;
        }
    }
}
