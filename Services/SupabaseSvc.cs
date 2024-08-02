using crossbid_blazor.Shared.Models;

namespace crossbid_blazor.Services;

public class SupabaseSvc
{
	private string _connectionUrl = "";
	private readonly Supabase.Client _supabase;

	public SupabaseSvc(IConfiguration configuration, Supabase.Client supabase) 
	{
		_supabase = supabase;
	}

	public async Task<List<Auction>> GetAuctionList()
	{
		var result = await _supabase.From<Auction>().Get();
		return result.Models!;
	}

	public async Task UploadToSupabase(string fileName, byte[] data)
	{
		await _supabase.Storage.From("temp").Upload(data, fileName, new Supabase.Storage.FileOptions { CacheControl = "1800", Upsert = true });
	}

	public async Task UpsertToSupabase(Auction auction)
	{
		await _supabase.From<Auction>().Upsert(auction);
	}
}
