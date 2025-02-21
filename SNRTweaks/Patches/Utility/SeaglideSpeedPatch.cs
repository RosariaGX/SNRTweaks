using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeaglideSpeedPatch
    {
        internal static float defaultseaglideForwardMaxSpeed;
        internal static float defaultseaglideBackwardMaxSpeed;
        internal static float defaultseaglideStrafeMaxSpeed;
        internal static float defaultseaglideVerticalMaxSpeed;
        internal static float defaultseaglideWaterAcceleration;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void SeaglideStart_Postfix(PlayerController __instance)
        {
            if (__instance is PlayerController seaglide)
            {
                defaultseaglideForwardMaxSpeed = seaglide.seaglideForwardMaxSpeed;
                defaultseaglideBackwardMaxSpeed = seaglide.seaglideBackwardMaxSpeed;
                defaultseaglideStrafeMaxSpeed = seaglide.seaglideStrafeMaxSpeed;
                defaultseaglideVerticalMaxSpeed = seaglide.seaglideVerticalMaxSpeed;
                defaultseaglideWaterAcceleration = seaglide.seaglideWaterAcceleration;

                seaglide.seaglideForwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideBackwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideStrafeMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideVerticalMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideWaterAcceleration *= Plugin.Options.seaglideSpeedMultiplier;
            }
        }

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Update)), HarmonyPostfix]
        private static void SeaglideUpdate_PostFix(PlayerController __instance)
        {
            if (__instance is PlayerController seaglide && Plugin.Options.wasSeaglideSliderChanged.Equals(true))
            {
                ResetSeaglideValues(seaglide);

                seaglide.seaglideForwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideBackwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideStrafeMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideVerticalMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideWaterAcceleration *= Plugin.Options.seaglideSpeedMultiplier;
                Plugin.Options.wasSeaglideSliderChanged = false;
            }
        } 

        private static void ResetSeaglideValues(PlayerController seaglide)
        {
            seaglide.seaglideForwardMaxSpeed = defaultseaglideForwardMaxSpeed;
            seaglide.seaglideBackwardMaxSpeed = defaultseaglideBackwardMaxSpeed;
            seaglide.seaglideStrafeMaxSpeed = defaultseaglideStrafeMaxSpeed;
            seaglide.seaglideVerticalMaxSpeed = defaultseaglideVerticalMaxSpeed;
            seaglide.seaglideWaterAcceleration = defaultseaglideWaterAcceleration;
        }
    }
}
