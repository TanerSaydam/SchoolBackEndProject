using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LessonManager>().As<ILessonService>();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>();

            builder.RegisterType<TeacherManager>().As<ITeacherService>();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>();

            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();
        }        
    }
}
