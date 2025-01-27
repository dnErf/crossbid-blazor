using crossbid_blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL") ?? builder.Configuration.GetValue<string>("SUPABASE:URL");
var supabasekey = Environment.GetEnvironmentVariable("SUPABASE_KEY") ?? builder.Configuration.GetValue<string>("SUPABASE:KEY");

builder.Services.AddSingleton(provider => new Supabase.Client(supabaseUrl!, supabasekey, new Supabase.SupabaseOptions {
	AutoRefreshToken = true,
	AutoConnectRealtime = true,
	// SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
}));

builder.Services.AddScoped<SupabaseSvc>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
