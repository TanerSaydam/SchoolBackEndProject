using Business.Abstract;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void Add(TeacherRegisterDto registerDto)
        {
            byte[] paswordHash, paswordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out paswordHash, out paswordSalt);
            Teacher teacher = new Teacher()
            {
                Gender = registerDto.Gender,
                Address = registerDto.Address,
                Id = 0,
                IdentityNumber = registerDto.IdentityNumber,
                IsActive = true,
                Name = registerDto.Name,
                PaswordHash = paswordHash,
                PaswordSalt = paswordSalt
            };

            _teacherDal.Add(teacher);
        }

        public List<Teacher> GetList()
        {
            var results = _teacherDal.GetList();
            return results;
        }
    }
}
