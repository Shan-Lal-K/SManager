using Microsoft.EntityFrameworkCore;
using STUDMANAG.SContext;
using STUDMANAG.Services.AccountsService;
using STUDMANAG.Services.PrincipalManagmentService;
using STUDMANAG.Services.RoleAspUserDetailsService;
using STUDMANAG.Services.RolesService;
using STUDMANAG.Services.SchoolManagmentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext Register
builder.Services.AddDbContext<SDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Service Connection (Repository Modal)
builder.Services.AddScoped<IAccountsService, AccountsServices>();
builder.Services.AddScoped<IRolesService, RolesServices>();
builder.Services.AddScoped<IRoleBasedUserDetailsService, RoleBasedUserDetailsService>();
builder.Services.AddScoped<ISchoolManagmentService, SchoolManagmentServices>();
builder.Services.AddScoped<IPrincipalService, PrincipalService>();

//Registering AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
