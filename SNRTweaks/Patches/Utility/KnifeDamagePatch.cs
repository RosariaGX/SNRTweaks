using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class KnifeDamagePatch
    {
        public static float defaultKnifeDamage;

        [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.Awake)), HarmonyPostfix]
        private static void KnifeDamageAwake_PostFix(PlayerTool __instance)
        {
            if (__instance is Knife knife)
            {
                defaultKnifeDamage = knife.damage;
                knife.damage *= Plugin.Options.knifeDamageMultiplier;
            }
        }

        [HarmonyPatch(typeof(Knife), nameof(Knife.OnToolUseAnim)), HarmonyPostfix]
        private static void KnifeDamageUpdate(Knife __instance)
        {
            if (Plugin.Options.wasKnifeSliderChanged.Equals(true))
            {
                ResetKnifeDamage(__instance);
                __instance.damage *= Plugin.Options.knifeDamageMultiplier;
                Plugin.Logger.LogInfo($"Knife Damage Multiplier Updated to: {Plugin.Options.knifeDamageMultiplier}");
                Plugin.Options.wasKnifeSliderChanged = false;
            }
        }

        public static void ResetKnifeDamage(Knife knife)
        {
            knife.damage = defaultKnifeDamage;
        }
    }
}
