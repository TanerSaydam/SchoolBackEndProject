using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILessonService
    {
        Result Add(Lesson lesson);
        void Update(Lesson lesson);
        DataResult<List<Lesson>> GetList();
        DataResult<Lesson> GetById(int id);
    }
}
