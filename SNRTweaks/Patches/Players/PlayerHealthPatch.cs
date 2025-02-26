using HarmonyLib;

namespace SNRTweaks.Patches.Players
{
    [HarmonyPatch]
    internal class PlayerHealthPatch
    {
        [HarmonyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage)), HarmonyPrefix] 
        private static void PlayerTakeDamage_Prefix()
        {
            if (Plugin.Options.isHealthCheatToggled)
            {
                var liveMixIn = Player.main?.GetComponent<LiveMixin>();

                liveMixIn.ResetHealth();
            } else { return; }
        }
    }
}
