using Inventario_Net6;

var builder = WebApplication.CreateBuilder(args);

//Agregar
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);



var app = builder.Build();


//Agregar
startup.Configure(app, app.Environment);


app.Run();

