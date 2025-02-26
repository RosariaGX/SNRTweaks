using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerHungerAndWaterPatch
    {
        private static float _defaultWater;
        private static float _defaultHunger;
        private static bool _wasToggled;

        [HarmonyPatch(typeof(Survival), nameof(Survival.UpdateStats)), HarmonyPrefix]
        private static void PlayerUpdateStats_Prefix(Survival instance)
        {
            _defaultWater = instance.water;
            _defaultHunger = instance.food;

            if (Plugin.Options.IsWaterAndHungerToggled)
            {
                instance.water = _defaultWater + 100.0f;
                instance.food = _defaultHunger + 100.0f;
                _wasToggled = true;
            } else 
            { 
                if (_wasToggled)
                {
                    float newHunger = instance.food - _defaultHunger;
                    float newWater = instance.water - _defaultWater;

                    instance.food = newHunger;
                    instance.water = newWater;
                    _wasToggled = false;
                } else { return;  }
                return;
            }
        }
    }
}
