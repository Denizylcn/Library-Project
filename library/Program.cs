using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMemberService, MemberManager>();
builder.Services.AddScoped<IMemberDal, EFMemberDal>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();

builder.Services.AddScoped<IAuthorDal, EFAuthorDal>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBookDal, EfBookDal>();
builder.Services.AddScoped<IBorrowingHistoryService,BorrowingHistoryManagement>();

builder.Services.AddScoped<IBorrowingHistoryDal,EFBorrowingHistory>();
builder.Services.AddDbContext<libraryDBContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=BookList}/{id?}");


app.Run();


