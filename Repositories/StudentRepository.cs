using Microsoft.EntityFrameworkCore;
using Student.Context;
using Student.Entity;

namespace Student.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public List<StudentEntity> FindAll()
        {
            return _context.Student.Include(c => c.ClassRoom).ToList();
        }

        public List<StudentEntity> FindAllBySchool(Guid schoolId)
        {
            return _context.Student.Include(c => c.ClassRoom).Where(c => c.classRoomId == schoolId).ToList();
        }

        public StudentEntity? FindById(Guid id)
        {
            return _context.Student.Find(id);
        }

        public StudentEntity Save(StudentEntity studentCreateDto)
        {
            var student = _context.Student.Add(studentCreateDto);
            _context.SaveChanges();

            return student.Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
