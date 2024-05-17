using Microsoft.AspNetCore.Mvc;
using School.Entity;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public ActionResult<PagedListDTO<SchoolEntity>> GetAll([FromQuery] int page = 1, [FromQuery]int pageSize = 10)
        {
            try
            {
                var result = _schoolService.GetAll(page, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SchoolEntity> GetById(Guid id)
        {
            try
            {
                var school = _schoolService.GetById(id);

                if (school == null)
                {
                    return NotFound();
                }

                return Ok(school);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] SchoolEntity SchoolCreateDto)
        {
            try
            {
                var createdSchool = _schoolService.Create(SchoolCreateDto);
                return Ok(createdSchool);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] SchoolEntity schoolUpdateDto)
        {
            try
            {
                return Ok(_schoolService.Update(id, schoolUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var deletedSchool = _schoolService.Delete(id);

                if (deletedSchool == null)
                {
                    return NotFound();
                }

                return Ok(deletedSchool);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
