using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICourseRepository Courses { get; }
        public ISessionRepository Sessions { get; }
        public IModuleRepository Modules { get; }
        public IQuizRepository Quizzes { get; }
        public IAssignmentRepository Assignments { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IAdminRepository Admins { get; } // Corrected from Users to Admins
        public IStudentRepository Students { get; } // Added for Student repository
        public IInstructorRepository Instructors { get; } // Added for Instructor repository

        public UnitOfWork(ApplicationDbContext context,
                          ICourseRepository courses,
                          ISessionRepository sessions,
                          IModuleRepository modules,
                          IQuizRepository quizzes,
                          IAssignmentRepository assignments,
                          IEnrollmentRepository enrollments,
                          IAdminRepository admins,
                          IStudentRepository students,
                          IInstructorRepository instructors)
        {
            _context = context;
            Courses = courses;
            Sessions = sessions;
            Modules = modules;
            Quizzes = quizzes;
            Assignments = assignments;
            Enrollments = enrollments;
            Admins = admins;
            Students = students;
            Instructors = instructors;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
