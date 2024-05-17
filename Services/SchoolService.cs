using ClassRoom.Entity;
using School.Entity;

namespace School.Service
{
    public class SchoolService: ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public PagedListDTO<SchoolEntity> GetAll(int page, int pageSize)
        {
            var total = _schoolRepository.Count();

            var schools = _schoolRepository.FindAll(page, pageSize);

            return new PagedListDTO<SchoolEntity>
            {
                total = total,
                page = page,
                pageSize = pageSize,
                items = schools
            };
        }

        public SchoolEntity? GetById(Guid id)
        {
            var school = _schoolRepository.FindById(id);

            if (school == null)
            {
                return null;
            }

            return school;
        }

        public SchoolEntity Create(SchoolEntity school)
        {
            return _schoolRepository.Save(school);
        }

        public SchoolEntity? Update(Guid id, SchoolEntity schoolUpdate)
        {
            var existingSchool = GetById(id);

            if (existingSchool == null)
            {
                return null;
            }

            existingSchool.name = schoolUpdate.name;
            existingSchool.cnpj = schoolUpdate.cnpj;
            existingSchool.phone = schoolUpdate.phone;
            existingSchool.email = schoolUpdate.email;

            _schoolRepository.SaveChanges();

            return existingSchool;
        }

        public SchoolEntity? Delete(Guid id)
        {
            var existingSchool = _schoolRepository.FindById(id);

            if (existingSchool == null)
            {
                return null;
            }

            _schoolRepository.Delete(existingSchool);
            _schoolRepository.SaveChanges();

            return existingSchool;
        }

    }
}
