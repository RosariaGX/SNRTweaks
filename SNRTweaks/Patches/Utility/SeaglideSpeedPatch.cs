using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeaglideSpeedPatch : MonoBehaviour
    {
        public static float defaultseaglideForwardMaxSpeed;
        public static float defaultseaglideBackwardMaxSpeed;
        public static float defaultseaglideStrafeMaxSpeed;
        public static float defaultseaglideVerticalMaxSpeed;
        public static float defaultseaglideWaterAcceleration;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void SeaglideStart_Postfix(PlayerController __instance)
        {
            defaultseaglideForwardMaxSpeed = __instance.seaglideForwardMaxSpeed;
            defaultseaglideBackwardMaxSpeed = __instance.seaglideBackwardMaxSpeed;
            defaultseaglideStrafeMaxSpeed = __instance.seaglideStrafeMaxSpeed;
            defaultseaglideVerticalMaxSpeed = __instance.seaglideVerticalMaxSpeed;
            defaultseaglideWaterAcceleration = __instance.seaglideWaterAcceleration;

            

            __instance.seaglideForwardMaxSpeed = SeaglideSpeedPatch.defaultseaglideForwardMaxSpeed * Plugin.Options.seaglideSpeedMultiplier;
            __instance.seaglideBackwardMaxSpeed = SeaglideSpeedPatch.defaultseaglideBackwardMaxSpeed * Plugin.Options.seaglideSpeedMultiplier;
            __instance.seaglideStrafeMaxSpeed = SeaglideSpeedPatch.defaultseaglideStrafeMaxSpeed * Plugin.Options.seaglideSpeedMultiplier;
            __instance.seaglideVerticalMaxSpeed = SeaglideSpeedPatch.defaultseaglideVerticalMaxSpeed * Plugin.Options.seaglideSpeedMultiplier;
            __instance.seaglideWaterAcceleration = SeaglideSpeedPatch.defaultseaglideWaterAcceleration * Plugin.Options.seaglideSpeedMultiplier;
            Player.main.UpdateMotorMode();
        }
    }
}
