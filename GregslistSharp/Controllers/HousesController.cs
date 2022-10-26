namespace GregslistSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _hs;

  public HousesController(HousesService hs)
  {
    _hs = hs;
  }


  [HttpGet]
  public ActionResult<List<House>> Get()
  {
    try
    {
      List<House> houses = _hs.GetHouses();
      return Ok(houses);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}")]
  public ActionResult<House> GetHouse(int id)
  {
    try
    {
      var house = _hs.GetHouse(id);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public ActionResult<House> Create([FromBody] House houseData)
  {
    try
    {

      House house = _hs.CreateHouse(houseData);
      return Ok(house);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  public ActionResult<House> Put(int id, [FromBody] House houseData)
  {
    try
    {
      houseData.Id = id;
      House house = _hs.EditHouse(houseData);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}