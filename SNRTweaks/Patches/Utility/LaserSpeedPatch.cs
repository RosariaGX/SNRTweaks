using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    internal class LaserSpeedPatch
    {
        private static float _defaultWeldSpeed;

        [HarmonyPatch(typeof(LaserCutter), nameof(LaserCutter.OnToolUseAnim)), HarmonyPostfix]
        private static void WelderOnToolUseAnim_Postfix(LaserCutter instance) 
        { 
            if (Plugin.Options.WasWelderSliderChanged)
            {
                _defaultWeldSpeed = instance.healthPerWeld;

                instance.healthPerWeld = _defaultWeldSpeed * Plugin.Options.WelderSpeedMultiplier;
            }
        }
    }
}
