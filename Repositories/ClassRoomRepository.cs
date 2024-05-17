using ClassRoom.Context;
using ClassRoom.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School.Entity;
using System.Drawing.Printing;

namespace ClassRoom.Repository
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly ClassRoomDbContext _context;

        public ClassRoomRepository(ClassRoomDbContext context)
        {
            _context = context;
        }

        public List<ClassRoomEntity> FindAll()
        {
            return _context.ClassRoom.Include(c => c.School).ToList();
        }
        public IEnumerable<ClassRoomEntity> FindAllBySchool(Guid schoolId, int page, int pageSize)
        {
            return _context.ClassRoom
                .Include(c => c.School)
                .Where(c => c.schoolId == schoolId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int Count()
        {
            return _context.ClassRoom.Count();
        }

        public ClassRoomEntity? FindById(Guid id)
        {
            return _context.ClassRoom.Find(id);
        }

        public ClassRoomEntity Save(ClassRoomEntity classCreateDto)
        {
            var classRoom = _context.ClassRoom.Add(classCreateDto);
            _context.SaveChanges();

            return classRoom.Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
