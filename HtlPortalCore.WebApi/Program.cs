using HtlPortalCore.DataAccess;
using HtlPortalCore.Handlers;
using HtlPortalCore.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// configure Serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

try
{
    Log.Information("HtlPortal.WebApi Initializing...");

    builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("HtlPortalDb"),
        options => options.MigrationsAssembly("HtlPortalCore.DataAccess")
     ));

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Register Services
    builder.Services.AddScoped<IUserService, UserService>();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    // Todo: Add Authorization
    app.UseSwagger();
    app.UseSwaggerUI();

    if (!app.Environment.IsDevelopment())
        app.UseExceptionHandler("/Error");
    else
        app.UseDeveloperExceptionPage();

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseStaticFiles();
    app.MapControllers();
    app.UseRouting();

    app.UseMiddleware<GlobalErrorHandler>();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal($"HtlPortalCore Failed: {ex.Message}");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
