namespace GregslistSharp.Services;

public class HousesService
{
  private readonly HousesRepository _hr;

  public HousesService(HousesRepository hr)
  {
    _hr = hr;
  }

  public List<House> GetHouses()
  {
    return _hr.GetHouses();
  }

  public House CreateHouse(House houseData)
  {
    return _hr.CreateHouse(houseData);
  }

  public House GetHouse(int id)
  {
    return _hr.GetHouse(id);
  }

  public House EditHouse(House houseData)
  {
    House original = GetHouse(houseData.Id);
    original.Bedrooms = houseData.Bedrooms ?? original.Bedrooms;
    original.Floors = houseData.Floors ?? original.Floors;
    original.Year = houseData.Year ?? original.Year;
    original.Description = houseData.Description ?? original.Description;
    original.Price = houseData.Price ?? original.Price;
    original.ImgUrl = houseData.ImgUrl ?? original.ImgUrl;

    return _hr.EditHouse(houseData);
  }

  public void RemoveCar(int id)
  {
    _hr.RemoveCar(id);

  }
}
