using HarmonyLib;
using UnityEngine;

namespace SNRTweaks.Patches.Vehicles
{
    [HarmonyPatch]
    public class SeamothSpeedPatch
    {
        private static float _defaultForwardForce;

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Awake)), HarmonyPostfix]
        private static void SeamothAwake_PostFix(SeaMoth instance) 
        {
            _defaultForwardForce = instance.forwardForce;

            instance.forwardForce *= Plugin.Options.SeamothSpeedMultiplier;
        }

        [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Update)), HarmonyPostfix]
        private static void SeamothUpdate_PostFix()
        {
            if (Plugin.Options.WasSeamothSliderChanged) 
            {
                foreach (var seamoths in Object.FindObjectsOfType<SeaMoth>())
                {
                    seamoths.forwardForce = _defaultForwardForce;

                    seamoths.forwardForce *= Plugin.Options.SeamothSpeedMultiplier;
                    Plugin.Options.WasSeamothSliderChanged = false;
                }
            }
        }
    }
}
