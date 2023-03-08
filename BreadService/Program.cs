using BreadService.Infra;
using Microsoft.EntityFrameworkCore;
using BreadService.Infra.Data;
using BreadService.Application.Bread;
using BreadService;

var app = Startup.InitializeApp(args);
app.Run();
