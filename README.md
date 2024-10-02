
# Fix Big Inventories ASF plugin

## DISCLAIMER

This plugin automates steam inventory actions and sends additional request to steam upon every trade. You are using it at your own risk, and agree that Author can't be held liable for whatever outcome that could follow from using this plugin

## Acknowledgements

This plugin uses 3rd party code from https://github.com/SmallTailTeam/SmallTail.Asf.BigInventoryFixer, limited by file `FixMethods.cs` and licensed under Apache 2.0 license. Modifications in this code can be checked in commit history.

## Description

According to user reports, if your inventory contains more than 50000 items, some trade requests may be marked as cancelled for no apparent reason. This plugin for [ArchiSteamFarm](https://github.com/JustArchiNet/ArchiSteamFarm) implements "quick and dirty" fix for trading bots with such big inventories. 
After each accepted and confirmed trade, it either packs gems to gem sack, or unpacks a gem sack to gems, depending on what is found first in inventory.
Obviously, for it to work, your bot needs to have either 1000+ gems or at least one gem sack.

## Installation

Work of this plugin is only guaranteed with [generic ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup), so if you use any other variant you are encouraged to switch to generic. Please don't report any issues if you are running some other variant, like `win-x64`, etc.
After that, download `FixBigInventories.zip` from [latest release page](https://github.com/CatPoweredPlugins/FixBigInventories/releases/latest), create new folder (called, for example, `FixBigInventories`) inside of ASF's `plugins` folder, and unpack downloaded archive there.
Now you have to configure the bots where this plugin should be triggered as explained below.

## Configuration

To enable triggering of this fix on a bot, you need to add to that's bot configuration file additional parameter:

```
  "EnableBigInventoryFix": true
```
Please notice, that you have to keep correct structure of .json file, so you need to add commas (`,`) between consequtive parameters - so, after a parameter that goes before this parameter, if any, and after this parameter, if there are other parameters following it.
