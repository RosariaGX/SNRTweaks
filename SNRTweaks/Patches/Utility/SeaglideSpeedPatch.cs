using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeaglideSpeedPatch
    {
        private static float defaultseaglideForwardMaxSpeed;
        private static float defaultseaglideBackwardMaxSpeed;
        private static float defaultseaglideStrafeMaxSpeed;
        private static float defaultseaglideVerticalMaxSpeed;
        private static float defaultseaglideWaterAcceleration;


        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void seaglideSpeedStart_Postfix(PlayerController __instance)
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
        public static void seaglideSpeedUpdate_PostFix(PlayerController __instance)
        {
            if (__instance is PlayerController seaglide && Plugin.Options.wasSliderChanged.Equals(true))
            {
                ResetSeaglideValues(seaglide);

                seaglide.seaglideForwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideBackwardMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideStrafeMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideVerticalMaxSpeed *= Plugin.Options.seaglideSpeedMultiplier;
                seaglide.seaglideWaterAcceleration *= Plugin.Options.seaglideSpeedMultiplier;
                Plugin.Options.wasSliderChanged = false;
            }
        } 

        public static void ResetSeaglideValues(PlayerController seaglide)
        {
            seaglide.seaglideForwardMaxSpeed = defaultseaglideForwardMaxSpeed;
            seaglide.seaglideBackwardMaxSpeed = defaultseaglideBackwardMaxSpeed;
            seaglide.seaglideStrafeMaxSpeed = defaultseaglideStrafeMaxSpeed;
            seaglide.seaglideVerticalMaxSpeed = defaultseaglideVerticalMaxSpeed;
            seaglide.seaglideWaterAcceleration = defaultseaglideWaterAcceleration;
        }
    }
}
