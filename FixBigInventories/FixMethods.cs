using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ArchiSteamFarm.Steam;
using ArchiSteamFarm.Steam.Data;
using ArchiSteamFarm.Steam.Integration;

namespace SmallTail.Asf.BigInventoryFixer;

public delegate Task<string?> InventoryFixMethod(Bot bot, Asset asset);

internal static class InventoryFixMethods {
	public static async Task<string?> ViaGemPacking(Bot bot, Asset asset) {
		if ((asset.Description?.MarketHashName != "753-Gems") || (asset.Amount < 1000)) {
			return null;
		}

		Dictionary<string, string> data = new Dictionary<string, string> {
			{ "appid", "753" },
			{ "assetid", asset.AssetID.ToString(CultureInfo.InvariantCulture) },
			{ "goo_denomination_in", "1" },
			{ "goo_amount_in", "1000" },
			{ "goo_denomination_out", "1000" },
			{ "goo_amount_out_expected", "1" }
		};

		bool response = await bot.ArchiWebHandler.UrlPostWithSession(
			new Uri($"https://steamcommunity.com/profiles/{bot.SteamID}/ajaxexchangegoo"),
			data: data,
			session: ArchiWebHandler.ESession.Lowercase
		).ConfigureAwait(false);

		return response ? "Fixed inventory via gem packing" : null;
	}

	public static async Task<string?> ViaGemUnpacking(Bot bot, Asset asset) {
		if (asset.Description?.MarketHashName != "753-Sack of Gems") {
			return null;
		}

		Dictionary<string, string> data = new Dictionary<string, string> {
			{ "appid", "753" },
			{ "assetid", asset.AssetID.ToString(CultureInfo.InvariantCulture) },
			{ "goo_denomination_in", "1000" },
			{ "goo_amount_in", "1" },
			{ "goo_denomination_out", "1" },
			{ "goo_amount_out_expected", "1000" }
		};

		bool response = await bot.ArchiWebHandler.UrlPostWithSession(
			new Uri($"https://steamcommunity.com/profiles/{bot.SteamID}/ajaxexchangegoo"),
			data: data,
			session: ArchiWebHandler.ESession.Lowercase
		).ConfigureAwait(false);

		return response ? "Fixed inventory via gem unpacking" : null;
	}
}
