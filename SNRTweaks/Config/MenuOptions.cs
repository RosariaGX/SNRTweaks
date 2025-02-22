using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using SNRTweaks.Patches.Utility;

namespace SNRTweaks.Config
{
    [Menu("SNRTweaks")]
    public class MenuOptions : ConfigFile
    {
        public bool wasKnifeSliderChanged = false;
        public bool wasSeamothSliderChanged = false;

        [Slider("Swim Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Player's swim speed will be multiplied by."), OnChange(nameof(SwimSpeedSliderChangeEvent))]
        public float swimSpeedMultiplier = 1.0f;
        
        [Slider("Run Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Player's swim speed will be multiplied by."), OnChange(nameof(RunSpeedSliderChangeEvent))]
        public float walkSpeedMultiplier = 1.0f;

        [Slider("Seaglide Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seaglide's speed will be multiplied by."), OnChange(nameof(SeaglideSpeedSliderChangeEvent))]
        public float seaglideSpeedMultiplier = 1.0f;

        [Slider("Knife Damage Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Knife's damage will be multiplied by."), OnChange(nameof(KnifeDamageSliderChangeEvent))]
        public float knifeDamageMultiplier = 1.0f;

        [Slider("Seamoth Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seamoth's speed will be multiplied by."), OnChange(nameof(SeamothSpeedSliderChangeEvent))]
        public float seamothSpeedMultiplier = 1.0f;

        private void SwimSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; }

            playerController.swimForwardMaxSpeed = PlayerSwimSpeedPatch.defaultSwimForwardSpeed * swimSpeedMultiplier;
            playerController.swimWaterAcceleration = PlayerSwimSpeedPatch.defaultSwimWaterAcceleration * swimSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Walk);
            Player.main.UpdateMotorMode();

        }
        private void RunSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; }

            playerController.walkRunForwardMaxSpeed = PlayerRunSpeedPatch.defaultWalkRunForwardSpeed * walkSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Dive);
            Player.main.UpdateMotorMode();

        }

        private void SeaglideSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; } 

            playerController.seaglideForwardMaxSpeed = SeaglideSpeedPatch.defaultseaglideForwardMaxSpeed * seaglideSpeedMultiplier;
            playerController.seaglideWaterAcceleration = SeaglideSpeedPatch.defaultseaglideWaterAcceleration * seaglideSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Dive);
            Player.main.UpdateMotorMode();

        }

        private void KnifeDamageSliderChangeEvent(SliderChangedEventArgs e)
        {
            knifeDamageMultiplier = e.Value;
            wasKnifeSliderChanged = true;
        }

        private void SeamothSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            seamothSpeedMultiplier = e.Value;
            wasSeamothSliderChanged = true;
        }
    }
}
