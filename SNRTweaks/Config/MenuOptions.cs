﻿using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using SNRTweaks.Patches.Players;
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
        
        [Slider("Run Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Player's Run speed will be multiplied by."), OnChange(nameof(RunSpeedSliderChangeEvent))]
        public float walkSpeedMultiplier = 1.0f;

        [Slider("Seaglide Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seaglide's speed will be multiplied by."), OnChange(nameof(SeaglideSpeedSliderChangeEvent))]
        public float seaglideSpeedMultiplier = 1.0f;

        [Slider("Knife Damage Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Knife's damage will be multiplied by."), OnChange(nameof(KnifeDamageSliderChangeEvent))]
        public float knifeDamageMultiplier = 1.0f;

        [Slider("Seamoth Speed Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}", Tooltip = "This is the amount that the Seamoth's speed will be multiplied by."), OnChange(nameof(SeamothSpeedSliderChangeEvent))]
        public float seamothSpeedMultiplier = 1.0f;

        [Toggle("Disable Bleeders", Tooltip = "This is an option to Enable or Disable all Bleeders from the game, You may need to reload save to take effect"), OnChange(nameof(BleedersToggleChangeEvent))]
        public bool areBleedersDisabled = false;

        [Toggle("Disable Warpers", Tooltip = "This is an option to Enable or Disable all Warpers from the game, You may need to reload save to take effect"), OnChange(nameof(WarpersToggleChangeEvent))]
        public bool areWarpersDisabled = false;
        
        [Toggle("Disable Reapers", Tooltip = "This is an option to Enable or Disable all Reapers from the game, You may need to reload save to take effect"), OnChange(nameof(ReapersToggleChangeEvent))]
        public bool areReapersDisabled = false;

        [Toggle("Disable Seadragons", Tooltip = "This is an option to Enable or Disable all Seadragons from the game, You may need to reload save to take effect"), OnChange(nameof(SeaDragonsToggleChangeEvent))]
        public bool areSeaDragonsDisabled = false;

        [Toggle("Disable Ghost Leviathans", Tooltip = "This is an option to Enable or Disable all Ghost Leviathans from the game, You may need to reload save to take effect"), OnChange(nameof(GhostLeviathansToggleChangeEvent))]
        public bool areGhostLeviathansDisabled = false;

        [Toggle("Disable Crabsquids", Tooltip = "This is an option to Enable or Disable all Crabsquids from the game (you're welcome RTGames), You may need to reload save to take effect"), OnChange(nameof(CrabsquidsToggleChangeEvent))]
        public bool areCrabsquidsDisabled = false;

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

        private void BleedersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areBleedersDisabled = e.Value;
        }

        private void WarpersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areBleedersDisabled = e.Value;
        }

        private void ReapersToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areReapersDisabled = e.Value;
        }

        private void SeaDragonsToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areSeaDragonsDisabled = e.Value;
        }

        private void GhostLeviathansToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areGhostLeviathansDisabled = e.Value;
        }

        private void CrabsquidsToggleChangeEvent(ToggleChangedEventArgs e)
        {
            areCrabsquidsDisabled = e.Value;
        }
    }
}
