using Student.Entity;

namespace Student.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return _studentRepository.FindAll();
        }

        public List<StudentEntity> GetAllBySchool(Guid schoolId)
        {
            return _studentRepository.FindAllBySchool(schoolId);
        }

        public StudentEntity? GetById(Guid id)
        {
            var student = _studentRepository.FindById(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }

        public StudentEntity Create(StudentEntity student)
        {
            return _studentRepository.Save(student);
        }

        public StudentEntity? Update(Guid id, StudentEntity studentUpdate)
        {
            var existingStudent = GetById(id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.name = studentUpdate.name;
            existingStudent.address = studentUpdate.address;
            existingStudent.guardian = studentUpdate.guardian;
            existingStudent.date = studentUpdate.date;
            existingStudent.phone = studentUpdate.phone;

            _studentRepository.SaveChanges();

            return existingStudent;
        }

    }
}
