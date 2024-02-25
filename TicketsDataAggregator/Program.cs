using TicketsDataAggregator.FileAccess;
using TicketsDataAggregator.TicketsAggregation;

const string ticketsFolder = @"/Users/alfredo/Downloads/Tickets";

try
{
    var ticketsAggregator = new TicketsAggregator(
        ticketsFolder,
        new FileWriter(),
        new DocumentsFromPdfsReader());

    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An exception ocurred. " +
        "Exception message: " + ex.Message);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
