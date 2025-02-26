using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerSwimSpeedPatch
    {
        public static float DefaultSwimForwardSpeed;
        public static float DefaultSwimWaterAcceleration;
        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void PlayerControllerStart_Postfix(PlayerController instance)
        {
            DefaultSwimForwardSpeed = instance.swimForwardMaxSpeed;
            DefaultSwimWaterAcceleration = instance.swimWaterAcceleration;

            instance.swimForwardMaxSpeed = DefaultSwimForwardSpeed * Plugin.Options.SwimSpeedMultiplier;
            instance.swimWaterAcceleration = DefaultSwimWaterAcceleration * Plugin.Options.SwimSpeedMultiplier;
            Player.main.UpdateMotorMode();
        }

    }
}
