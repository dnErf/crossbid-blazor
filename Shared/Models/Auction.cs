using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace crossbid_blazor.Shared.Models;

[Table("crossbid_auctions")]
public class Auction : BaseModel
{
	[PrimaryKey("id")]
	public Guid Id { get; set; } = Guid.NewGuid();

	[Column("user_id")]
	public Guid UserId { get; set; } = Guid.NewGuid();

	[Column("name")]
	public string Name { get; set; } = "";

	[Column("image_url")]
	public string ImageUrl { get; set; } = "";

	[Column("cents_starting_price")]
	public double CentsStartingPrice { get; set; }

	[Column("cents_current_bid")]
	public double CentsCurrentBid { get; set; }

	[Column("cents_bid_interval")]
	public double CentsBidInterval { get; set; }

	[Column("end_at")]
	public DateTime EndAt { get; set; } = DateTime.UtcNow;
}
