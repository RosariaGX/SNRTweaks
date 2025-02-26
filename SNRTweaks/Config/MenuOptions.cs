using Nautilus.Extensions;
using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using SNRTweaks.Patches.Players;
using SNRTweaks.Patches.Utility;

namespace SNRTweaks.Config
{
    [Menu("SNRTweaks")]
    public class MenuOptions : ConfigFile
    {
        public bool WasKnifeSliderChanged = false;
        public bool WasSeamothSliderChanged = false;
        public bool WasWelderSliderChanged = false;
        public bool WasLaserSliderChanged = false;

        [Slider("Swim Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Player's swim speed will be multiplied by."), OnChange(nameof(SwimSpeedSliderChangeEvent))]
        public float SwimSpeedMultiplier = 1.0f;
        
        [Slider("Run Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Player's Run speed will be multiplied by."), OnChange(nameof(RunSpeedSliderChangeEvent))]
        public float WalkSpeedMultiplier = 1.0f;

        [Slider("Seaglide Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seaglide's speed will be multiplied by."), OnChange(nameof(SeaglideSpeedSliderChangeEvent))]
        public float SeaglideSpeedMultiplier = 1.0f;

        [Slider("Knife Damage Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Knife's damage will be multiplied by."), OnChange(nameof(KnifeDamageSliderChangeEvent))]
        public float KnifeDamageMultiplier = 1.0f;

        [Slider("Repair Tool Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Repair Tool's speed will be multiplied by."), OnChange(nameof(WelderSpeedSliderChangeEvent))]
        public float WelderSpeedMultiplier = 1.0f;

        [Slider("Laser Cutter Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Laser Cutter's speed will be multiplied by."), OnChange(nameof(LaserSpeedSliderChangeEvent))]
        public float LaserSpeedMultiplier = 1.0f;

        [Slider("Seamoth Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seamoth's speed will be multiplied by."), OnChange(nameof(SeamothSpeedSliderChangeEvent))]
        public float SeamothSpeedMultiplier = 1.0f;

        [Toggle("Oxygen Cheat", Tooltip = "This is an option to enable or disable the NoOxygen console command"), OnChange(nameof(OxygenCheatToggleChangeEvent))]
        public bool IsNoOxygenToggled;

        [Toggle("Health Cheat", Tooltip = "This is an option to enable or disable taking damage, Please note that this DOESN'T prevent one shot kills e.g. Reapers eating you or getting killed by the Aurora explosion e.t.c"), OnChange(nameof(HealthCheatToggleChangeEvent))]
        public bool IsHealthCheatToggled;

        [Toggle("Hunger & Water Cheat", Tooltip = "This is an option to enable or disable hunger and water"), OnChange(nameof(WaterAndHungerCheatToggleChangeEvent))]
        public bool IsWaterAndHungerToggled;

        [Toggle("Disable Bleeders", Tooltip = "This is an option to Enable or Disable all Bleeders from the game, You may need to reload save to take effect"), OnChange(nameof(BleedersToggleChangeEvent))]
        public bool AreBleedersDisabled;

        [Toggle("Disable Lava Larva", Tooltip = "This is an option to Enable or Disable all Lava Larva from the game, You may need to reload save to take effect"), OnChange(nameof(LarvaToggleChangeEvent))]
        public bool AreLarvaDisabled;

        [Toggle("Disable Warpers", Tooltip = "This is an option to Enable or Disable all Warpers from the game, You may need to reload save to take effect"), OnChange(nameof(WarpersToggleChangeEvent))]
        public bool AreWarpersDisabled = false;
        
        [Toggle("Disable Reapers", Tooltip = "This is an option to Enable or Disable all Reapers from the game, You may need to reload save to take effect"), OnChange(nameof(ReapersToggleChangeEvent))]
        public bool AreReapersDisabled;

        [Toggle("Disable Seadragons", Tooltip = "This is an option to Enable or Disable all Seadragons from the game, You may need to reload save to take effect"), OnChange(nameof(SeaDragonsToggleChangeEvent))]
        public bool AreSeaDragonsDisabled;

        [Toggle("Disable Ghost Leviathans", Tooltip = "This is an option to Enable or Disable all Ghost Leviathans from the game, You may need to reload save to take effect"), OnChange(nameof(GhostLeviathansToggleChangeEvent))]
        public bool AreGhostLeviathansDisabled;

        [Toggle("Disable Crabsquids", Tooltip = "This is an option to Enable or Disable all Crabsquids from the game (you're welcome RTGames), You may need to reload save to take effect"), OnChange(nameof(CrabsquidsToggleChangeEvent))]
        public bool AreCrabsquidsDisabled;

        private void SwimSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; }

            playerController.swimForwardMaxSpeed = PlayerSwimSpeedPatch.DefaultSwimForwardSpeed * SwimSpeedMultiplier;
            playerController.swimWaterAcceleration = PlayerSwimSpeedPatch.DefaultSwimWaterAcceleration * SwimSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Walk);
            Player.main.UpdateMotorMode();

        }
        private void RunSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; }

            playerController.walkRunForwardMaxSpeed = PlayerRunSpeedPatch.DefaultWalkRunForwardSpeed * WalkSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Dive);
            Player.main.UpdateMotorMode();

        }

        private void SeaglideSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            var playerController = Player.main?.playerController;

            if (playerController == null) { return; } 

            playerController.seaglideForwardMaxSpeed = SeaglideSpeedPatch.DefaultSeaglideForwardMaxSpeed * SeaglideSpeedMultiplier;
            playerController.seaglideWaterAcceleration = SeaglideSpeedPatch.DefaultSeaglideWaterAcceleration * SeaglideSpeedMultiplier;

            Player.main.SetMotorMode(Player.MotorMode.Dive);
            Player.main.UpdateMotorMode();

        }

        private void KnifeDamageSliderChangeEvent(SliderChangedEventArgs e)
        {
            KnifeDamageMultiplier = e.Value;
            WasKnifeSliderChanged = true;
        }

        private void WelderSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            WelderSpeedMultiplier = e.Value;
            WasWelderSliderChanged = true;
        }

        private void LaserSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            WelderSpeedMultiplier = e.Value;
            WasLaserSliderChanged = true;
        }

        private void SeamothSpeedSliderChangeEvent(SliderChangedEventArgs e)
        {
            SeamothSpeedMultiplier = e.Value;
            WasSeamothSliderChanged = true;
        }

        private void OxygenCheatToggleChangeEvent(ToggleChangedEventArgs e)
        {
            IsNoOxygenToggled = e.Value;
        }

        private void HealthCheatToggleChangeEvent(ToggleChangedEventArgs e)
        {
            IsHealthCheatToggled = e.Value;
        }

        private void WaterAndHungerCheatToggleChangeEvent(ToggleChangedEventArgs e)
        {
            IsWaterAndHungerToggled = e.Value;
        }

        private void BleedersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreBleedersDisabled = e.Value;
        }

        private void LarvaToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreLarvaDisabled = e.Value;
        }

        private void WarpersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreBleedersDisabled = e.Value;
        }

        private void ReapersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreReapersDisabled = e.Value;
        }

        private void SeaDragonsToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreSeaDragonsDisabled = e.Value;
        }

        private void GhostLeviathansToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreGhostLeviathansDisabled = e.Value;
        }

        private void CrabsquidsToggleChangeEvent(ToggleChangedEventArgs e)
        {
            AreCrabsquidsDisabled = e.Value;
        }
    }
}
