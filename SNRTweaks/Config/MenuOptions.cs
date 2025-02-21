using HarmonyLib;
using Nautilus.Extensions;
using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using SNRTweaks.Patches.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTweaks.Config
{
    

    [Menu("SNRTweaks")]
    public class MenuOptions : ConfigFile
    {
        public bool wasSliderChanged = false;

        [Slider("Seaglide Speed Multiplier", 0.0f, 25.0f, DefaultValue = 0.0f, Format = "{0:F2}", Tooltip = "This is the amount that the seaglide's speed will be multiplied by."), OnChange(nameof(seaglideSpeedSliderChangeEvent))]
        public float seaglideSpeedMultiplier = 1.0f;

        public void seaglideSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            seaglideSpeedMultiplier = e.Value;
            wasSliderChanged = true;
        }
    }
}
