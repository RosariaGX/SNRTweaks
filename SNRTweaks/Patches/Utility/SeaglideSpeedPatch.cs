using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class SeaglideSpeedPatch
    {
        public static float defaultseaglideForwardMaxSpeed;
        public static float defaultseaglideWaterAcceleration;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void SeaglideStart_Postfix(PlayerController __instance)
        {
            defaultseaglideForwardMaxSpeed = __instance.seaglideForwardMaxSpeed;
            defaultseaglideWaterAcceleration = __instance.seaglideWaterAcceleration;

            __instance.seaglideForwardMaxSpeed = defaultseaglideForwardMaxSpeed * Plugin.Options.seaglideSpeedMultiplier;
            __instance.seaglideWaterAcceleration = defaultseaglideWaterAcceleration * Plugin.Options.seaglideSpeedMultiplier;
            Player.main.UpdateMotorMode();  
        }
    }
}
