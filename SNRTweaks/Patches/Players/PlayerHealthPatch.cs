using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerHealthPatch
    {
        [HarmonyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage)), HarmonyPostfix] 
        private static void PlayerTakeDamage_Postfix()
        {
            if (Plugin.Options.IsHealthCheatToggled)
            {
                var liveMixIn = Player.main?.GetComponent<LiveMixin>();

                liveMixIn!.ResetHealth();
            } else { return; }
        }
    }
}
