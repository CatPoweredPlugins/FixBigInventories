
# Fix Big Inventories ASF plugin

## DISCLAIMER

This plugin automates steam inventory actions and sends additional request to steam upon every trade. You are using it at your own risk, and agree that Author can't be held liable for whatever outcome that could follow from using this plugin

## Acknowledgements

This plugin uses

## Description

This is a plugin for [ArchiSteamFarm](https://github.com/JustArchiNet/ArchiSteamFarm) that implements "quick and dirty" fix for trading bots with big inventories.
After each accepted and confirmed trade, it either packs gems to gem sack, or unpacks a gem sack to gems, depending on what is found first in inventory.
Obviously, for it to work, your bot needs to have either 1000+ gems or at least one gem sack.

## Installation

Work of this plugin is only guaranteed with [generic ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup), so if you use any other variant you are encouraged to switch to generic. Please don't report any issues if you are running some other variant, like `win-x64`, etc.
After that, download `CommandAliasPlugin.zip` from [latest release page](https://github.com/Rudokhvist/CommandAliasPlugin/releases/latest), create new folder (called, for example, `CommandAliasPlugin`) inside of ASF's `plugins` folder, and unpack downloaded archive there.
Now you have to configure aliases you want in `ASF.json` file in `config` folder of your ASF installation, as described below. If your ASF is configured to not restart after global config edits - restart it manually, and if you did everything right - your aliases should work now.


## Configuration
