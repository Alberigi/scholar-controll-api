using ClassRoom.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Entity;
using School.Repository;
using System.Drawing.Printing;

namespace ClassRoom.Service
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public IEnumerable<ClassRoomEntity> GetAll()
        {
            return _classRoomRepository.FindAll();
        }

        public PagedListDTO<ClassRoomEntity> GetAllBySchool(Guid schoolId, int page, int pageSize)
        {
            var total = _classRoomRepository.Count();
            var schools = _classRoomRepository.FindAllBySchool(schoolId, page, pageSize);

            return new PagedListDTO<ClassRoomEntity>
            {
                total = total,
                page = page,
                pageSize = pageSize,
                items = schools
            };
        }

        public ClassRoomEntity? GetById(Guid id)
        {
            var classRoom = _classRoomRepository.FindById(id);

            if (classRoom == null)
            {
                return null;
            }

            return classRoom;
        }

        public ClassRoomEntity Create(ClassRoomEntity classRoom)
        {
            return _classRoomRepository.Save(classRoom);
        }

        public ClassRoomEntity? Update(Guid id, ClassRoomEntity classRoomUpdate)
        {
            var existingClassRoom = GetById(id);

            if (existingClassRoom == null)
            {
                return null;
            }

            existingClassRoom.name = classRoomUpdate.name;
            existingClassRoom.shift = classRoomUpdate.shift;
            existingClassRoom.grade = classRoomUpdate.grade;
            existingClassRoom.academicYear = classRoomUpdate.academicYear;

            _classRoomRepository.SaveChanges();

            return existingClassRoom;
        }

    }
}
