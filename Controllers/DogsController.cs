using DogApi.BLL;
using DogApi.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DogsController : ControllerBase
{

    private readonly ILogger<DogsController> _logger;

    public DogsController(ILogger<DogsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<List<Dog>> GetDogs()
    {
        try
        {
            return DogHandlerFactory.GetDogHandler().GetDogs().ToList();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Dog> GetDog(Guid id)
    {
        try
        {
            var dog = DogHandlerFactory.GetDogHandler().GetDog(id);
            return dog == null ? NotFound() : dog;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Dog> GetDog(DogRequest dogRequest)
    {
        try
        {
            return DogHandlerFactory.GetDogHandler().SaveNewDog(dogRequest);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return BadRequest();
        }
    }
}