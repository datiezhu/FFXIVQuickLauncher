﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CheapLoc;

namespace XIVLauncher.Windows.ViewModel
{
    class SettingsControlViewModel : INotifyPropertyChanged
    {
        private string _gamePath;

        public SettingsControlViewModel()
        {
            SetupLoc();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets a value indicating whether the "Run Integrity Checks" button is enabled.
        /// </summary>
        public bool IsRunIntegrityCheckPossible =>
            !string.IsNullOrEmpty(GamePath) && Directory.Exists(GamePath);

        /// <summary>
        /// Gets or sets the path to the game folder.
        /// </summary>
        public string GamePath
        {
            get => _gamePath;
            set
            {
                _gamePath = value;
                OnPropertyChanged(nameof(GamePath));
                OnPropertyChanged(nameof(IsRunIntegrityCheckPossible));
            }
        }

        private void SetupLoc()
        {
            SettingsGameLoc = Loc.Localize("SettingsGame", "Game");
            GamePathLoc = Loc.Localize("ChooseGamePath",
                "Please select the folder your game is installed in.\r\nIt should contain the folders \"game\" and \"boot\".");
            SteamCheckBoxLoc = Loc.Localize("FirstTimeSteamCheckBox", "Enable Steam integration");
            AdditionalArgumentsLoc = Loc.Localize("AdditionalArguments", "Additional launch arguments");
            RunIntegrityCheckLoc = Loc.Localize("RunIntegrityCheck", "Run integrity check");
            RunIntegrityCheckTooltipLoc =
                Loc.Localize("RunIntegrityCheckTooltip", "Run integrity check on game files.");

            SettingsGameSettingsLoc = Loc.Localize("SettingsGameSettings", "Game Settings");
            DirectXLoc = Loc.Localize("ChooseDirectX", "Please select which DirectX version you want to use.");
            DirectX9NoticeLoc = Loc.Localize("DirectX9Notice",
                "DirectX 9 mode is not supported anymore. It will still start, but you will not get support from\r\nSE for any technical issues any additional XIVLauncher features such as Rich Presence and the\r\nIn-Game addon will not work.");
            ChooseLanguageLoc = Loc.Localize("ChooseLanguage", "Please select which language you want to load the game with.");

            SettingsAutoLaunchLoc = Loc.Localize("SettingsAutoLaunch", "Auto-Launch");
            AutoLaunchHintLoc = Loc.Localize("AutoLaunchHint",
                "These are applications that are started as soon as the game has started.");
            RemoveLoc = Loc.Localize("Remove", "Remove");
            AddNewLoc = Loc.Localize("AddNew", "Add new");
            AutoLaunchAddNewToolTipLoc =
                Loc.Localize("AutoLaunchAddNewToolTip", "Add a new Auto-Start entry that allows you to launch any program.");

            SettingsInGameLoc = Loc.Localize("SettingsInGame", "In-Game");
            InGameAddonDescriptionLoc = Loc.Localize("InGameAddonDescription",
                "These options affect the XIVLauncher in-game features. These features will be automatically\r\nenabled if you are running the DirectX 11 version of the game, the version of the game is\r\ncompatible, and the checkbox below is ticked.");
            InGameAddonCommandHintLoc = Loc.Localize("InGameAddonCommandHint",
                "When enabled, type \"/xlhelp\" in-game to see other available commands.");
            InGameAddonEnabledCheckBoxLoc = Loc.Localize("InGameAddonEnabledCheckBox", "Enable in-game features");
            InGameAddonChatSettingsLoc = Loc.Localize("ChatSettings", "Chat settings");
            InGameAddonDiscordBotTokenLoc = Loc.Localize("DiscordBotToken", "Discord Bot Token");
            InGameAddonHowLoc = Loc.Localize("HowToHint", "How do I set this up?");
            InGameAddonAddChatChannelLoc = Loc.Localize("AddChatChannel", "Add chat channel");
            InGameAddonSetCfChannelLoc = Loc.Localize("InGameAddonSetCfChannel", "Set Duty Finder notification channel");
            InGameAddonSetRouletteChannelLoc = Loc.Localize("InGameAddonSetRouletteChannel", "Set Roulette Bonus notification channel");
            InGameAddonSetRetainerChannelLoc = Loc.Localize("InGameAddonSetRetainerChannel", "Set retainer sale channel");
            InGameAddonChatDelayLoc = Loc.Localize("InGameAddonChatDelay", "Chat Post Delay");
            InGameAddonChatDelayDescriptionLoc = Loc.Localize("InGameAddonChatDelayDescription",
                "Check for recently sent messages to avoid duplicates.\r\nThis allows for multiple users to use the same channel as a chat log.\r\nPlease set an appropriate delay in milliseconds below(e.g. 1000).");
            UniversalisHintLoc = Loc.Localize("UniversalisHint",
                "Market board data provided in cooperation with Universalis.");
            UniversalisOptOutLoc = Loc.Localize("UniversalisOptOut",
                "Opt-out of contributing anonymously to crowd-sourced market board information");
            DutyFinderTaskbarFlashLoc = Loc.Localize("DutyFinderTaskbarFlash",
                "Flash the game's taskbar entry when Duty Finder queue pops");
            
            PluginsDescriptionLoc = Loc.Localize("PluginsDescriptionLoc",
                "These are the plugins that are currently available installed on your machine.");
            PluginsToggleLoc = Loc.Localize("Toggle", "Toggle");
            PluginsInstallHintLoc =
                Loc.Localize("PluginsInstallHint", "You can use the /xlplugins command in-game to install more plugins.");

            SettingsAboutLoc = Loc.Localize("SettingsAbout", "About");
            CreditsLoc = Loc.Localize("Credits",
                "Made by goat.\r\nSpecial thanks to Mino, sky, LeonBlade, Wintermute, Zyian,\r\nRoy, Meli, Aida Enna, and the angry paissa artist!\r\n\r\nAny issues or requests? Join the discord or create an issue on GitHub!");
            JoinDiscordLoc = Loc.Localize("JoinDiscord", "Join Discord");
            StartBackupToolLoc = Loc.Localize("StartBackupTool", "Start Backup Tool");
            StartOriginalLauncherLoc = Loc.Localize("StartOriginalLauncher", "Start Original Launcher");
            EnabledUidCacheLoc = Loc.Localize("EnabledUidCache", "Enable experimental UID cache(might behave weirdly)");
            EnableEncryptionLoc = Loc.Localize("EnableEncryption", "Enable encrypting arguments to the client");
        }

        public string SettingsGameLoc { get; private set; }
        public string GamePathLoc { get; private set; }
        public string SteamCheckBoxLoc { get; private set; }
        public string AdditionalArgumentsLoc { get; private set; }
        public string RunIntegrityCheckLoc { get; private set; }
        public string RunIntegrityCheckTooltipLoc { get; private set; }

        public string SettingsGameSettingsLoc { get; private set; }
        public string DirectXLoc { get; private set; }
        public string DirectX9NoticeLoc { get; private set; }
        public string ChooseLanguageLoc { get; private set; }

        public string SettingsAutoLaunchLoc { get; private set; }
        public string AutoLaunchHintLoc { get; private set; }
        public string RemoveLoc { get; private set; }
        public string AddNewLoc { get; private set; }
        public string AutoLaunchAddNewToolTipLoc { get; private set; }

        public string SettingsInGameLoc { get; private set; }
        public string InGameAddonDescriptionLoc { get; private set; }
        public string InGameAddonCommandHintLoc { get; private set; }
        public string InGameAddonEnabledCheckBoxLoc { get; private set; }
        public string InGameAddonChatSettingsLoc { get; private set; }
        public string InGameAddonDiscordBotTokenLoc { get; private set; }
        public string InGameAddonHowLoc { get; private set; }
        public string InGameAddonAddChatChannelLoc { get; private set; }
        public string InGameAddonSetCfChannelLoc { get; private set; }
        public string InGameAddonSetRouletteChannelLoc { get; private set; }
        public string InGameAddonSetRetainerChannelLoc { get; private set; }
        public string InGameAddonChatDelayLoc { get; private set; }
        public string InGameAddonChatDelayDescriptionLoc { get; private set; }
        public string UniversalisHintLoc { get; private set; }
        public string UniversalisOptOutLoc { get; private set; }
        public string DutyFinderTaskbarFlashLoc { get; private set; }

        public string PluginsDescriptionLoc { get; private set; }
        public string PluginsToggleLoc { get; private set; }
        public string PluginsInstallHintLoc { get; private set; }

        public string SettingsAboutLoc { get; private set; }
        public string CreditsLoc { get; private set; }
        public string JoinDiscordLoc { get; private set; }
        public string StartBackupToolLoc { get; private set; }
        public string StartOriginalLauncherLoc { get; private set; }
        public string EnabledUidCacheLoc { get; private set; }
        public string EnableEncryptionLoc { get; private set; }
    }
}
