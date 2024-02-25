using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.UserInteraction;

public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(
        IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Show(IEnumerable<Planet> planets)
    {
        TablePrinter.Print(planets);
    }

    public void ShowMessage(string message)
    {
        _userInteractor.ShowMessage(message);
    }

    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage(
            "The statistics of which property would you" +
            "like to see?");
        _userInteractor.ShowMessage(
            string.Join(
                Environment.NewLine,
                propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }
}