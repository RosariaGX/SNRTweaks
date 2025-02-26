using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    internal class SeaglideSpeedPatch
    {
        public static float DefaultSeaglideForwardMaxSpeed;
        public static float DefaultSeaglideWaterAcceleration;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void SeaglideStart_Postfix(PlayerController instance)
        {
            DefaultSeaglideForwardMaxSpeed = instance.seaglideForwardMaxSpeed;
            DefaultSeaglideWaterAcceleration = instance.seaglideWaterAcceleration;

            instance.seaglideForwardMaxSpeed = DefaultSeaglideForwardMaxSpeed * Plugin.Options.SeaglideSpeedMultiplier;
            instance.seaglideWaterAcceleration = DefaultSeaglideWaterAcceleration * Plugin.Options.SeaglideSpeedMultiplier;
            Player.main.UpdateMotorMode();  
        }
    }
}
