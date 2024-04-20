using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.EntityFrameworkCore;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<GymContext>(options =>
                      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MembersRepository>();
builder.Services.AddScoped<SubscriptionRepository>();
builder.Services.AddScoped<MemberSubscripitonsRepository>();
builder.Services.AddScoped<DiscountsRepository>();
builder.Services.AddScoped<DiscountedMemberSubscriptionRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .SetIsOriginAllowedToAllowWildcardSubdomains(); ;
                      });
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();