using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.UserInteraction;

public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    void ShowMessage(string message);
    string? ChooseStatisticsToBeShown(
        IEnumerable<string> propertiesThatCanBeChosen);
}