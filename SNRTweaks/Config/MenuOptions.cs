using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;


namespace SNRTweaks.Config
{
    

    [Menu("SNRTweaks")]
    public class MenuOptions : ConfigFile
    {
        public bool wasSeaglideSliderChanged = false;
        public bool wasKnifeSliderChanged = false;

        [Slider("Seaglide Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the seaglide's speed will be multiplied by."), OnChange(nameof(seaglideSpeedSliderChangeEvent))]
        public float seaglideSpeedMultiplier = 1.0f;

        [Slider("Knife Damage Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Knife's damage will be multiplied by."), OnChange(nameof(KnifeDamageSliderChangeEvent))]
        public float knifeDamageMultiplier = 1.0f;

        public void seaglideSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            seaglideSpeedMultiplier = e.Value;
            wasSeaglideSliderChanged = true;
        }

        private void KnifeDamageSliderChangeEvent(SliderChangedEventArgs e)
        {
            knifeDamageMultiplier = e.Value;
            wasKnifeSliderChanged = true;
        }
    }
}
