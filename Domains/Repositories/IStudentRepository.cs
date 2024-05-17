using Student.Entity;

public interface IStudentRepository
{
    List<StudentEntity> FindAll();

    List<StudentEntity> FindAllBySchool(Guid schoolId);

    StudentEntity? FindById(Guid id);

    StudentEntity Save(StudentEntity studentCreateDto);

    void SaveChanges();
}
