using Microsoft.AspNetCore.Mvc;
using ClassRoom.Entity;
using School.Service;
using School.Entity;

namespace ClassRoom.Controllers
{
    [ApiController]
    [Route("School/{schoolId}/[controller]")]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        [HttpGet]
        public ActionResult<PagedListDTO<ClassRoomEntity>> GetAll(Guid schoolId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = _classRoomService.GetAllBySchool(schoolId, page, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClassRoomEntity> GetById(Guid id)
        {
            try
            {
                var classRoom = _classRoomService.GetById(id);

                if (classRoom == null)
                {
                    return NotFound();
                }

                return Ok(classRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClassRoomEntity SchoolCreateDto)
        {
            try
            {
                var createdSchool = _classRoomService.Create(SchoolCreateDto);
                return Ok(createdSchool);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ClassRoomEntity classRoomUpdateDto)
        {
            try
            {
                return Ok(_classRoomService.Update(id, classRoomUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
