using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.CommentsService;
using MongoMflix.API.Services.EmbeddedMoviesService;
using MongoMflix.API.Services.MoviesService;
using MongoMflix.API.Services.SessionsService;
using MongoMflix.API.Services.TheaterService;
using MongoMflix.API.Services.UsersService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Data base settings
builder.Services.Configure<DataBaseSettings>(
        builder.Configuration.GetSection("MyDb")
    );

// Resolving Comments Service Dependency
builder.Services.AddTransient<ICommentsService, CommentsService>();

// Resolving Embedded Movies Service Dependency
builder.Services.AddTransient<IEmbeddedService, EmbeddedService>();

// Resoving Movies Service Dependency
builder.Services.AddTransient<IMoviesService,  MoviesService>();

// Resolving Sessions Dependency
builder.Services.AddTransient<ISessionsService, SessionsService>();

// Resolving Theaters Dependency
builder.Services.AddTransient<ITheatersService, TheatersService>();

// Resolving Users Dependency
builder.Services.AddTransient<IUsersService, UsersService>();

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
