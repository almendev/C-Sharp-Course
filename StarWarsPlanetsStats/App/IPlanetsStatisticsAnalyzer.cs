using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.App;

public interface IPlanetsStatisticsAnalyzer
{
    void Analize(IEnumerable<Planet> planets);
}
