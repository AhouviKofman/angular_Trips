using dal.functions;
using dal.interfaces;
using dal.models;
using bll.functions;
using bll.interfaces;
using Microsoft.EntityFrameworkCore;
using dal;
using dto.classes;
using bll.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TripsContext>(options => options.UseSqlServer("Server=.;Database=TripsContex;TrustServerCertificate=True;Trusted_Connection=True;"));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IUser), typeof(FuseresDal));
builder.Services.AddScoped(typeof(IUserBll), typeof(FuseresBll));

builder.Services.AddScoped(typeof(ItripesTypeDal), typeof(FTripsTypeDal));
builder.Services.AddScoped(typeof(ItripesTypeBll), typeof(FtripesTypeBll
));

builder.Services.AddScoped(typeof(IBooking), typeof(FBookingDal));
builder.Services.AddScoped(typeof(IBookingBll), typeof(FBooking));

builder.Services.AddScoped(typeof(ITripDal), typeof(FTripDal));
builder.Services.AddScoped(typeof(ITripBll), typeof(FTripBll));

builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",//נתינת שם להרשאה
    p => p.AllowAnyOrigin()//מאפשר כל מקור
    .AllowAnyMethod()//כל מתודה - פונקציה
    .AllowAnyHeader()));//וכל כותרת פונקציה

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//});


var app=builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
    ;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
