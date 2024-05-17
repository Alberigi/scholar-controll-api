using ClassRoom.Entity;
using School.Entity;

public interface IClassRoomRepository
{
    List<ClassRoomEntity> FindAll();

    IEnumerable<ClassRoomEntity> FindAllBySchool(Guid schoolId, int page, int pageSize);

    int Count();

    ClassRoomEntity? FindById(Guid id);

    ClassRoomEntity Save(ClassRoomEntity classRoomCreateDto);

    void SaveChanges();
}
