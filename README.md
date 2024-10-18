
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

![downloads](https://img.shields.io/github/downloads/CatPoweredPlugins/FixBigInventories/total.svg?style=social)
[![PayPal donate](https://img.shields.io/badge/PayPal-donate-00457c.svg?logo=paypal&logoColor=rgb(1,63,113))](https://www.paypal.com/donate/?business=SX99L4RVR8ZKS&no_recurring=0&item_name=Your+donations+help+me+to+keep+working+on+existing+and+future+plugins+for+ASF.+I+really+appreciate+this%21&currency_code=USD)
[![Ko-Fi donate](https://img.shields.io/badge/Ko%E2%80%91Fi-donate-ef5d5a.svg?logo=ko-fi)](https://ko-fi.com/rudokhvist)
[![BTC donate](https://img.shields.io/badge/BTC-donate-f7931a.svg?logo=bitcoin)](https://www.blockchain.com/explorer/addresses/btc/bc1q8f3zcss5j6gq7hpvum0nzxvfgnm5f8mtxflfxh)
[![LTC donate](https://img.shields.io/badge/LTC-donate-485fc7.svg?logo=litecoin&logoColor=rgb(92,115,219))](https://litecoinblockexplorer.net/address/LRFrKDFhyEgv7PKb2vFrdYBP7ibUg898Vk)
[![Steam donate](https://img.shields.io/badge/Steam-donate-000000.svg?logo=steam)](https://steamcommunity.com/tradeoffer/new/?partner=95843925&token=NTWfCz_R)
