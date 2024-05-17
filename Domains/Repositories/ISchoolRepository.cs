using School.Entity;

public interface ISchoolRepository
{
    IEnumerable<SchoolEntity> FindAll(int page, int pageSize);

    int Count();

    SchoolEntity? FindById(Guid id);

    SchoolEntity Save(SchoolEntity SchoolCreateDto);

    void SaveChanges();

    void Delete(SchoolEntity school);
}
