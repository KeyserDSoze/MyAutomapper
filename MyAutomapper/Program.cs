// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using MyAutomapper;
using Rystem;
using System.Numerics;

Console.WriteLine("Hello, World!");


var table = new TableIdentityCard()
{
    Id = Guid.NewGuid().ToString(),
    Name = "Fabio Rigoliti",
    IsMale = false,
    Position = "3,4,5"
};

var services = ServiceLocator.Create();
services.AddRystem();
services.AddMapping<TableIdentityCard, IdentityCard>(options =>
{
    options.AddAction<string, Vector3>("PositionValue",
        value => new Vector3(float.Parse(value.Split(',')[0]), float.Parse(value.Split(',')[1]), float.Parse(value.Split(',')[2])));
});
services.AddMapping<IdentityCard, TableIdentityCard>(options =>
{
    options.AddAction<Vector3, string>("Position",
        value => $"{value.X},{value.Y},{value.Z}");
});
services.FinalizeWithoutDependencyInjection();
//DateTime start = DateTime.UtcNow;
//var identityCard = table.To<TableIdentityCard, IdentityCard>();
//Console.WriteLine(DateTime.UtcNow.Ticks - start.Ticks);
//start = DateTime.UtcNow;
//var identityCard2 = table.To<TableIdentityCard, IdentityCard>();
//Console.WriteLine(DateTime.UtcNow.Ticks - start.Ticks);
//Console.WriteLine(identityCard);
//Console.WriteLine(identityCard2);

//MapManager mapManager = new MapManager();
//var identityCard3 = mapManager.To<TableIdentityCard, IdentityCard>(table);
//Console.WriteLine(identityCard3);

//MapManager<TableIdentityCard, IdentityCard> mapManager1 = new();
//var identityCard4 = mapManager1.To(table);
//Console.WriteLine(identityCard4);
var manager = ServiceLocator.GetService<MapManager<TableIdentityCard, IdentityCard>>();
var identityCard = manager.To(table);
var manager2 = ServiceLocator.GetService<MapManager<IdentityCard, TableIdentityCard>>();
var table2 = manager2.To(identityCard);
Console.WriteLine(identityCard);
Console.WriteLine(table2);