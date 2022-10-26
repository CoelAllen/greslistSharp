namespace GregslistSharp.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }
  public List<House> GetHouses()
  {
    var sql = "SELECT * FROM houses";
    return _db.Query<House>(sql).ToList();
  }

  public House CreateHouse(House houseData)
  {
    var sql = @"INSERT INTO 
    houses(
      bedrooms, floors, year, description, price, imgUrl
    )
    VALUES(
      @Bedrooms, @Floors, @Year, @Description, @Price, @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";
    houseData.Id = _db.ExecuteScalar<int>(sql, houseData);
    return houseData;
  }

  public House EditHouse(House houseData)
  {
    var sql = @"
   UPDATE houses SET
      bedrooms = @Bedrooms,
      floors = @Floors,
      year = @Year, 
      description = @Description,
      price = @Price,
      imgUrl = @ImgUrl
    WHERE id = @Id;";
    // NOTE Commas before wheres are bad 
    var rowsAffected = _db.Execute(sql, houseData);
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to Edit");
    }
    return houseData;
  }

  public void RemoveCar(int id)
  {
    var sql = @"
    DELETE FROM houses WHERE id = @id;";
    _db.Execute(sql, new { id });
  }

  public House GetHouse(int id)
  {
    var sql = "SELECT * FROM houses WHERE Id =id";
    return _db.Query<House>(sql).FirstOrDefault();
  }


}