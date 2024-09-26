using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;
using ArchiSteamFarm.Plugins.Interfaces;
using ArchiSteamFarm.Steam;
using ArchiSteamFarm.Steam.Data;
using ArchiSteamFarm.Steam.Exchange;
using JetBrains.Annotations;
using SmallTail.Asf.BigInventoryFixer;

namespace FixBigInventories;
#pragma warning disable CA1863
#pragma warning disable CA1812 // ASF uses this class during runtime
[UsedImplicitly]
internal sealed class FixBigInventories : IGitHubPluginUpdates, IBotModules, IBotTradeOfferResults {
	private readonly HashSet<Bot> EnabledBots = new();
	public string Name => nameof(FixBigInventories);
	public string RepositoryName => "CatPoweredPlugins/FixBigInventories";
	public Version Version => typeof(FixBigInventories).Assembly.GetName().Version ?? throw new InvalidOperationException(nameof(Version));

	public Task OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo($"{Name} by Rudokhvist. This plugin is cat-powered!");

		return Task.CompletedTask;
	}

	public async Task OnBotTradeOfferResults(Bot bot, IReadOnlyCollection<ParseTradeResult> tradeResults) {
		if (EnabledBots.Contains(bot) && bot.IsConnectedAndLoggedOn) {
			if (tradeResults.Any(static result => result is { Result: ParseTradeResult.EResult.Accepted, Confirmed: true })) {
				bool success = false;

				await foreach (Asset item in bot.ArchiHandler.GetMyInventoryAsync().Where(static elem => elem.Type == EAssetType.SteamGems)) {
					bot.ArchiLogger.LogGenericInfo("Big inventory fix triggered");

					if (item.Description?.MarketHashName == "753-Sack of Gems") {
						success = await InventoryFixMethods.ViaGemUnpacking(bot, item).ConfigureAwait(false) != null;
					} else if (item.Amount >= 1000) {
						success = await InventoryFixMethods.ViaGemPacking(bot, item).ConfigureAwait(false) != null;
					}

					if (success) {
						break;
					}
				}

				if (success) {
					bot.ArchiLogger.LogGenericInfo("Big inventory fix finished successfully");
				} else {
					bot.ArchiLogger.LogGenericWarning("Big inventory fix failed");
				}
			}
		}
	}

	public Task OnBotInitModules(Bot bot, IReadOnlyDictionary<string, JsonElement>? additionalConfigProperties = null) {
		if (additionalConfigProperties == null) {
			return Task.CompletedTask;
		}

		if (additionalConfigProperties.Any(static configProperty => configProperty.Key.Equals("EnableBigInventoryFix", StringComparison.OrdinalIgnoreCase) && (configProperty.Value.ValueKind == JsonValueKind.True))) {
			EnabledBots.Add(bot);
		}

		return Task.CompletedTask;
	}
}
#pragma warning restore CA1812 // ASF uses this class during runtime
#pragma warning restore CA1863
