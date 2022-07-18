using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace react.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Student_Context _dbContext;

        public WeatherForecastController(Student_Context dbContext)

        {
            this._dbContext = dbContext;
            
        }
        [HttpPost]
        [Route("SaveStudent")]
        public StudentVM RegisterUser(StudentVM student)
        {
          
            try
            {
                if (student.Type == "Add")
                {
                    Student_Entity students = new();
                    students.Id = student.Id;
                    students.FirstName = student.FirstName;
                    students.LastName = student.LastName;
                    students.Email = student.Email;
                    students.Mobile = student.Mobile;
                    _dbContext.student.Add(students);
                }
                if (student.Type == "Edit")
                {
                    Student_Entity students = _dbContext.student.Where(k => k.Id == student.Id).Select(k => k).FirstOrDefault();

                    students.FirstName = student.FirstName;
                    students.LastName = student.LastName;
                    students.Email = student.Email;
                    students.Mobile = student.Mobile;
                    _dbContext.Entry(student).State = EntityState.Modified;
                }
                if (student.Type == "Delete")
                {
                    Student_Entity students = _dbContext.student.Where(k => k.Id == student.Id).Select(k => k).FirstOrDefault();

                    _dbContext.student.Remove(students);
                }
                _dbContext.SaveChanges();
                return student;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<List<Student_Entity>> GetAllStudents()
        {

            try
            {
                List<Student_Entity> lststudents = (await _dbContext.student.ToListAsync());
                return lststudents;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        [Route("GetStudent")]
        public Student_Entity GetStudent(int Id)
        {

            try
            {
                return (_dbContext.student.Where(k => k.Id == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}