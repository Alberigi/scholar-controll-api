using ClassRoom.Entity;
using School.Entity;

public interface IClassRoomService
{
    IEnumerable<ClassRoomEntity> GetAll();

    PagedListDTO<ClassRoomEntity> GetAllBySchool(Guid schoolId, int page, int pageSize);

    ClassRoomEntity? GetById(Guid id);

    ClassRoomEntity Create(ClassRoomEntity schoolCreateDto);

    ClassRoomEntity? Update(Guid id, ClassRoomEntity classRoomUpdateDTO);
}
