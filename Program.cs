
using School.Service;
using School.Repository;
using School.Context;
using ClassRoom.Repository;
using ClassRoom.Service;
using ClassRoom.Context;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<IClassRoomService, ClassRoomService>();

builder.Services.AddTransient<ISchoolRepository, SchoolRepository>();
builder.Services.AddTransient<IClassRoomRepository, ClassRoomRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContext<SchoolDbContext>();
builder.Services.AddDbContext<ClassRoomDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
