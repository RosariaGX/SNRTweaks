using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class KnifeDamagePatch
    {
        internal static float defaultKnifeDamage;

        [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.Awake)), HarmonyPostfix]
        private static void KnifeAwake_PostFix(PlayerTool __instance)
        {
            if (__instance is Knife knife)
            {
                defaultKnifeDamage = knife.damage;
                knife.damage *= Plugin.Options.knifeDamageMultiplier;
            }
        }

        [HarmonyPatch(typeof(Knife), nameof(Knife.OnToolUseAnim)), HarmonyPostfix]
        private static void KnifeUpdate_PostFix(Knife __instance)
        {
            if (Plugin.Options.wasKnifeSliderChanged.Equals(true))
            {
                ResetKnifeValues(__instance);
                __instance.damage *= Plugin.Options.knifeDamageMultiplier;
                Plugin.Logger.LogInfo($"Knife Damage Multiplier Updated to: {Plugin.Options.knifeDamageMultiplier}");
                Plugin.Options.wasKnifeSliderChanged = false;
            }
        }

        private static void ResetKnifeValues(Knife knife)
        {
            knife.damage = defaultKnifeDamage;
        }
    }
}
