using School.Context;
using School.Entity;

namespace School.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDbContext _context;

        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SchoolEntity> FindAll(int page, int pageSize)
        {
            return _context.School.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int Count()
        {
            return _context.School.Count();
        }

        public SchoolEntity? FindById(Guid id)
        {
            return _context.School.Find(id);
        }

        public SchoolEntity Save(SchoolEntity schoolCreateDto)
        {
            var school = _context.School.Add(schoolCreateDto);
            _context.SaveChanges();

            return school.Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(SchoolEntity school)
        {
            _context.School.Remove(school);
        }
    }
}
