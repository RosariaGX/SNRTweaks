using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerRunSpeedPatch
    {
        public static float DefaultWalkRunForwardSpeed;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void PlayerControllerStart_Postfix(PlayerController instance)
        {
            DefaultWalkRunForwardSpeed = instance.walkRunForwardMaxSpeed;

            instance.swimForwardMaxSpeed = DefaultWalkRunForwardSpeed * Plugin.Options.WalkSpeedMultiplier;
            Player.main.UpdateMotorMode();
        }
    }
}
