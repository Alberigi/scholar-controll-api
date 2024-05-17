using Microsoft.AspNetCore.Mvc;
using Student.Entity;

namespace Student.Controllers
{
    [ApiController]
    [Route("School/{schoolId}/ClassRoom/{classRoomId}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Array>> Get(Guid schoolId)
        {
            try
            {
                return Ok(_studentService.GetAllBySchool(schoolId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<StudentEntity> GetById(Guid id)
        {
            try
            {
                var student = _studentService.GetById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] StudentEntity studentCreateDto)
        {
            try
            {
                var createdStudent = _studentService.Create(studentCreateDto);
                return Ok(createdStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] StudentEntity studentUpdateDto)
        {
            try
            {
                return Ok(_studentService.Update(id, studentUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
