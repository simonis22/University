using Azure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Application.Common.Users;
using University.Domain.Entities;
using University.Domain.Models;

namespace University.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : Controller
    {
        private readonly IUniversityServices _universityServices;
        private readonly ILogger<UniversityController> _logger;
        public UniversityController(IUniversityServices universityServices, ILogger<UniversityController> logger)
        {
            _universityServices = universityServices;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromForm] StudentModel model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError("Invalid Submission!");
                    return Content("Invalid Submission!");
                }
                //Insert in Student Model
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                };
                await _universityServices.UpsertAsync(student);
                _logger.LogInformation("Student created successfully with id: " + student.Id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("User not created. " + ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("CreateLecturer")]
        public async Task<IActionResult> CreateLecturer([FromForm] LecturerModel model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError("Invalid Submission!");
                    return Content("Invalid Submission!");
                }
                //Insert in Lecturer Model
                var lecturer = new Lecturer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                };
                await _universityServices.UpsertAsync(lecturer);
                _logger.LogInformation("Lecturer created successfully with id: " + lecturer.Id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Lecturer not created. " + ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromForm] CourseModel model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError("Invalid Submission!");
                    return Content("Invalid Submission!");
                }
                //Insert in Course Model
                var course = new Course
                {
                    Name = model.Name,
                };
                await _universityServices.UpsertAsync(course);
                _logger.LogInformation("Course created successfully with id: " + course.Id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Course not created. " + ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("EnrollStudent")]
        public async Task<IActionResult> EnrollStudent([FromForm] StudentCourseModel model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError("Invalid Submission!");
                    return Content("Invalid Submission!");
                }
                //Insert in StudentCourse Model
                var studentCourse = new StudentCourse
                {
                    StudentId = model.StudentId,
                    CourseId = model.CourseId,
                };
                await _universityServices.EnrollStudentAsync(studentCourse);
                _logger.LogInformation("StudentCourse created successfully with id: " + studentCourse.Id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("StudentCourse not created. " + ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("AssignLecturer")]
        public async Task<IActionResult> AssignLecturer([FromForm] AssignLecturerModel model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError("Invalid Submission!");
                    return Content("Invalid Submission!");
                }
                //Insert in LecturerCourse Model
                var lecturerCourse = new Course
                {
                    Id = model.Id,
                    LecurerId = model.LecturerId,
                };
                await _universityServices.UpsertAsync(lecturerCourse);
                _logger.LogInformation("LecturerCourse created successfully with id: " + lecturerCourse.Id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("LecturerCourse not created. " + ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> GetStudents(string? name)
        {
            try
            {
                var students = await _universityServices.GetStudentsAsync(name);
                if (students != null)
                {
                    _logger.LogInformation("Students retrieve successfully");
                    return Ok(students);
                }
                else
                {
                    _logger.LogInformation("Students not found");
                    return Ok("Students not found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetLecturers")]
        public async Task<IActionResult> GetLecturers(string? name)
        {
            try
            {
                var lecturers = await _universityServices.GetLecturersAsync(name);
                if (lecturers != null)
                {
                    _logger.LogInformation("Lecturers retrieve successfully");
                    return Ok(lecturers);
                }
                else
                {
                    _logger.LogInformation("Lecturers not found");
                    return Ok("Lecturers not found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetStudentsForLecturer")]
        public async Task<IActionResult> GetStudentsForLecturer(int id)
        {
            try
            {
                var students = await _universityServices.GetStudentsForLecturerAsync(id);
                if (students != null)
                {
                    _logger.LogInformation("Students retrieve successfully");
                    return Ok(students);
                }
                else
                {
                    _logger.LogInformation("Students not found");
                    return Ok("Students not found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id:int}")]
        [Route("DeleteStudent")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                await _universityServices.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteCourse(int id)
        {
            try
            {
                await _universityServices.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
