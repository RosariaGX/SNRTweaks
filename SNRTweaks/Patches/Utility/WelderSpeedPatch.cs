using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    internal class WelderSpeedPatch
    {
        private static float _defaultWeldSpeed;

        [HarmonyPatch(typeof(Welder), nameof(Welder.OnToolUseAnim)), HarmonyPostfix]
        private static void WelderOnToolUseAnim_Postfix(Welder instance) 
        { 
            if (Plugin.Options.WasWelderSliderChanged)
            {
                _defaultWeldSpeed = instance.healthPerWeld;

                instance.healthPerWeld = _defaultWeldSpeed * Plugin.Options.WelderSpeedMultiplier;
            }
        }
    }
}
