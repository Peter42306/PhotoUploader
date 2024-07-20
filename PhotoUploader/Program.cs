using Microsoft.EntityFrameworkCore;
using PhotoUploader.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// ��������� ������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������������ ������� � ������ � ����� wwwroot
// ����� ��������� ���������� � wwwroot �� ����� ���������� app.UseStaticFiles();
app.UseStaticFiles();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
