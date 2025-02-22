using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class PlayerRunSpeedPatch
    {
        public static float defaultWalkRunForwardSpeed;

        [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Start)), HarmonyPostfix]
        private static void PlayerControllerStart_Postfix(PlayerController __instance)
        {
            defaultWalkRunForwardSpeed = __instance.walkRunForwardMaxSpeed;

            __instance.swimForwardMaxSpeed = defaultWalkRunForwardSpeed * Plugin.Options.walkSpeedMultiplier;
            Player.main.UpdateMotorMode();
        }
    }
}
