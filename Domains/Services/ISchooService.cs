using School.Entity;

public interface ISchoolService
{
    PagedListDTO<SchoolEntity> GetAll(int page, int pageSize);

    SchoolEntity? GetById(Guid id);

    SchoolEntity Create(SchoolEntity schoolCreateDto);

    SchoolEntity? Update(Guid id, SchoolEntity schoolUpdateDto);

    SchoolEntity? Delete(Guid id);
}
