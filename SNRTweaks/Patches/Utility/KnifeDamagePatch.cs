using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    internal class KnifeDamagePatch
    {
        private static float _defaultKnifeDamage;

        [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.Awake)), HarmonyPostfix]
        private static void KnifeAwake_PostFix(PlayerTool instance)
        {
            if (instance is Knife knife)
            {
                _defaultKnifeDamage = knife.damage;
                knife.damage *= Plugin.Options.KnifeDamageMultiplier;
            }
        }

        [HarmonyPatch(typeof(Knife), nameof(Knife.OnToolUseAnim)), HarmonyPostfix]
        private static void KnifeUpdate_PostFix(Knife instance)
        {
            if (Plugin.Options.WasKnifeSliderChanged)
            {
                instance.damage = _defaultKnifeDamage * Plugin.Options.KnifeDamageMultiplier;
                Plugin.Options.WasKnifeSliderChanged = false;
            }
        }
    }
}
