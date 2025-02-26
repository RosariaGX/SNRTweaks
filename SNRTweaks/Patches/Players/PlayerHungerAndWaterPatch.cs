using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerHungerAndWaterPatch
    {
        private static float defaultWater;
        private static float defaultHunger;
        private static bool wasToggled = false;

        [HarmonyPatch(typeof(Survival), nameof(Survival.UpdateStats)), HarmonyPrefix]
        private static void PlayerUpdateStats_Prefix(Survival __instance)
        {
            defaultWater = __instance.water;
            defaultHunger = __instance.food;

            if (Plugin.Options.isWaterAndHungerToggled)
            {
                __instance.water = defaultWater + 100.0f;
                __instance.food = defaultHunger + 100.0f;
                wasToggled = true;
            } else 
            { 
                if (wasToggled)
                {
                    float newHunger = __instance.food - defaultHunger;
                    float newWater = __instance.water - defaultWater;
                    wasToggled = false;
                } else { return;  }
                return;
            }
        }
    }
}
