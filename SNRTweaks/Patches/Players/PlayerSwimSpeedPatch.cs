using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    public class PlayerSwimSpeedPatch
    {
        public static float defaultSwimForwardSpeed;
        public static float defaultSwimWaterAcceleration;
        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void PlayerControllerStart_Postfix(PlayerController __instance)
        {
            defaultSwimForwardSpeed = __instance.swimForwardMaxSpeed;
            defaultSwimWaterAcceleration = __instance.swimWaterAcceleration;

            __instance.swimForwardMaxSpeed = defaultSwimForwardSpeed * Plugin.Options.swimSpeedMultiplier;
            __instance.swimWaterAcceleration = defaultSwimWaterAcceleration * Plugin.Options.swimSpeedMultiplier;
            Player.main.UpdateMotorMode();
        }

    }
}
