using HarmonyLib;

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
        private static void SeamothUpdate_PostFix(SeaMoth seamoth)
        {
            if (Plugin.Options.wasSeamothSliderChanged.Equals(true))
            {
                ResetSeamothValues(seamoth);

                seamoth.forwardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.backwardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.sidewardForce *= Plugin.Options.seamothSpeedMultiplier;
                seamoth.verticalForce *= Plugin.Options.seamothSpeedMultiplier;

                Plugin.Options.wasSeamothSliderChanged = false;
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
