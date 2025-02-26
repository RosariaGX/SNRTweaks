using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerOxygenPatch
    {
        private static float _defaultOxygenAmount;
        private static float _newOxygenAmount;
        [HarmonyPatch(typeof(OxygenManager), nameof(OxygenManager.RemoveOxygen)), HarmonyPrefix] 
        private static void PlayerOnRemoveOxygen_Prefix()
        {
            var oxygenManager = Player.main?.GetComponent<OxygenManager>();

            _defaultOxygenAmount = Player.main!.GetOxygenCapacity();
            bool wasOxygenCheatEnabled = false;

            if (Plugin.Options.IsNoOxygenToggled)
            {
                _newOxygenAmount = oxygenManager!.AddOxygen(oxygenManager.GetOxygenAvailable());
                wasOxygenCheatEnabled = true;
            } else 
            { 
                if (wasOxygenCheatEnabled)
                {
                    float diff = _defaultOxygenAmount - _newOxygenAmount;
                    oxygenManager.RemoveOxygen(diff);
                } else { return; }
                return;
            }
        }
    }
}
