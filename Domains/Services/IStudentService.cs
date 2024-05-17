using Student.Entity;

public interface IStudentService
{
    IEnumerable<StudentEntity> GetAll();

    List<StudentEntity> GetAllBySchool(Guid schoolId);

    StudentEntity? GetById(Guid id);

    StudentEntity Create(StudentEntity studentCreateDto);

    StudentEntity? Update(Guid id, StudentEntity studentUpdateDTO);
}
