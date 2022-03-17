// See https://aka.ms/new-console-template for more information
using MyAutomapper;

Console.WriteLine("Hello, World!");


var table = new TableIdentityCard()
{
    Id = Guid.NewGuid().ToString(),
    Name = "Fabio Rigoliti",
    IsMale = false
};
DateTime start = DateTime.UtcNow;
var identityCard = table.To<TableIdentityCard, IdentityCard>();
Console.WriteLine(DateTime.UtcNow.Ticks - start.Ticks);
start = DateTime.UtcNow;
var identityCard2 = table.To<TableIdentityCard, IdentityCard>();
Console.WriteLine(DateTime.UtcNow.Ticks - start.Ticks);
Console.WriteLine(identityCard);
Console.WriteLine(identityCard2);

MapManager mapManager = new MapManager();
var identityCard3 = mapManager.To<TableIdentityCard, IdentityCard>(table);
Console.WriteLine(identityCard3);