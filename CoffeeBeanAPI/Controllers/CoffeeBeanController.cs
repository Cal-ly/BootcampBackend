using Microsoft.AspNetCore.Mvc;

namespace CoffeeBeanAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeBeanController : ControllerBase
{
    private readonly CoffeeBeanRepository _repository;

    public CoffeeBeanController(CoffeeBeanRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CoffeeBean>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CoffeeBean> GetById(int id)
    {
        try
        {
            var coffeeBean = _repository.GetById(id);
            return Ok(coffeeBean);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CoffeeBean> Add([FromBody] CoffeeBean coffeeBean)
    {
        try
        {
            coffeeBean.ValidateName();
            coffeeBean.ValidateRoasting();
            coffeeBean.ValidatePrice();

            _repository.Add(coffeeBean);
            return CreatedAtAction(nameof(GetById), new { id = coffeeBean.Id }, coffeeBean);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(int id, [FromBody] CoffeeBean coffeeBean)
    {
        try
        {
            coffeeBean.ValidateName();
            coffeeBean.ValidateRoasting();
            coffeeBean.ValidatePrice();

            _repository.Update(id, coffeeBean);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        try
        {
            _repository.Remove(id);
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}
