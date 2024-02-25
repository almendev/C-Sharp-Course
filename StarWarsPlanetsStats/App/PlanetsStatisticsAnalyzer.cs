using StarWarsPlanetsStats.Model;
using StarWarsPlanetsStats.UserInteraction;

namespace StarWarsPlanetsStats.App;

public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;
    
    public PlanetsStatisticsAnalyzer(
            IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    private readonly Dictionary<string, Func<Planet, long?>>
        _propertyNamesToSelectorMapping =
            new ()
            {
                ["population"] = planet => planet.Population,
                ["diameter"] = planet => planet.Diameter,
                ["surface Water"] = planet => planet.SurfaceWater,
            };

    public void Analize(IEnumerable<Planet> planets)
    {
        var userChoice = _planetsStatsUserInteractor
            .ChooseStatisticsToBeShown(
                _propertyNamesToSelectorMapping.Keys);

        if (userChoice is null ||
            !_propertyNamesToSelectorMapping.ContainsKey(userChoice))
        {
            Console.WriteLine("Invalid choice.");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                _propertyNamesToSelectorMapping[userChoice]);
        }
    }

    private static void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, long?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);
    }

    private static void ShowStatistics(
        string descriptor,
        Planet selectedPlanet,
        Func<Planet, long?> propertySelector,
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} " +
            $"{propertySelector(selectedPlanet)} " +
            $"(planet: {selectedPlanet.Name})");
    }
}