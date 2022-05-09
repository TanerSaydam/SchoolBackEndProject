using Business.Abstract;
using Business.Constans;
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
    public class LessonManager : ILessonService
    {
        private ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public Result Add(Lesson lesson)
        {
            Result result = new Result()
            {
                Message = Messages.AddedLesson,
                Success = true
            };

            _lessonDal.Add(lesson);
            return result;
        }

        public void Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
        }

        public DataResult<Lesson> GetById(int id)
        {
            DataResult<Lesson> dataResult = new DataResult<Lesson>()
            {
                Data = _lessonDal.Get(p => p.Id == id),
                Message = Messages.GetLesson,
                Success = true
            };
            return dataResult;
        }

        public DataResult<List<Lesson>> GetList()
        {
            var result = _lessonDal.GetList();
            DataResult<List<Lesson>> dataResult = new DataResult<List<Lesson>>()
            {
                Data = result,
                Message = Messages.GetListLesson,
                Success = true
            };
            return dataResult;
        }
    }
}
