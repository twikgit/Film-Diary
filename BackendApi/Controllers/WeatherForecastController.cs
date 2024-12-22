using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
            {
                return Ok(Summaries);
            }
            else if (sortStrategy == 1)
            {
                return Ok(Summaries.OrderBy(s => s).ToList());
            }
            else if (sortStrategy == -1)
            {
                return Ok(Summaries.OrderByDescending(s => s).ToList());
            }
            else
            {
                return BadRequest("������������ �������� ��������� sortStrategy");
            }
        }

        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("�������� ������");
            }

            return Ok(Summaries[index]);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetCountByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("��� �� ����� ���� ������");
            }

            int count = Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Ok(count);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("��� �� ����� ���� ������");
            }

            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("�������� ������");
            }

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("��� �� ����� ���� ������");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("�������� ������");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}
