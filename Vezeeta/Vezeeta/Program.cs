



using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repository.AdminRepository.DashboardRepository;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using RepositoryLayer.Repository.AdminRepository.PatientRepository;
using RepositoryLayer.Repository.AdminRepository.SettigRepository;
using RepositoryLayer.Repository.AdminRepository.SettingRepository;
using RepositoryLayer.Repository.DoctorRepository.DoctorBookingRepository;
using RepositoryLayer.Repository.DoctorRepository.SettingRepository;
using ServiceLayer.AdminService.DashboardService;
using ServiceLayer.AdminService.DoctorServices;
using ServiceLayer.AdminService.PatientService;
using ServiceLayer.DoctorService.DoctorBookingService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var ConnString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                 throw new InvalidOperationException("Can`t Find This connection String");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>();

//Injection for Admin
builder.Services.AddScoped<IAdminDoctorService, AdminDoctorService>();
builder.Services.AddScoped<IAdminDoctorRepository, AdminDoctorRepository>();

builder.Services.AddScoped<IAdminPatientService, AdminPatientService>();
builder.Services.AddScoped<IAdminPatientRepository, AdminPatientRepository>();


builder.Services.AddScoped<IAdminSettingService, AdminSettingService>();
builder.Services.AddScoped<IAdminSettingRepository, AdminSettingRepository>();

builder.Services.AddScoped<IAdminDashboardRepository, AdminDashboardRepository>();
builder.Services.AddScoped<IAdminDashboardService , AdminDashboardService>();
//Injection for Doctor
builder.Services.AddScoped<IDoctorSettingRepository, DoctorSettingRepository>();
builder.Services.AddScoped<IDoctorSettingService , DoctorSettingService>(); 

builder.Services.AddScoped<IDoctorBookingRepository, DoctorBookingRepository>();
builder.Services.AddScoped<IDoctorBookingService, DoctorBookingService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
