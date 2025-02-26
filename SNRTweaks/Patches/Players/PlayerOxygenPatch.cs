using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerOxygenPatch
    {
        private static float defaultOxygenAmount;
        private static float newOxygenAmount;
        [HarmonyPatch(typeof(OxygenManager), nameof(OxygenManager.RemoveOxygen)), HarmonyPrefix] 
        private static void PlayerOnRemoveOxygen_Prefix()
        {
            var oxygenManager = Player.main?.GetComponent<OxygenManager>();

            defaultOxygenAmount = Player.main.GetOxygenCapacity();
            bool wasOxygenCheatEnabled = false;

            if (Plugin.Options.isNoOxygenToggled)
            {
                newOxygenAmount = oxygenManager.AddOxygen(oxygenManager.GetOxygenAvailable());
                wasOxygenCheatEnabled = true;
            } else 
            { 
                if (wasOxygenCheatEnabled)
                {
                    float diff = defaultOxygenAmount - newOxygenAmount;
                    oxygenManager.RemoveOxygen(diff);
                } else { return; }
                return;
            }
        }
    }
}
