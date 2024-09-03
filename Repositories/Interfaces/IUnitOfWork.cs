using System;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ISessionRepository Sessions { get; }
        IModuleRepository Modules { get; }
        IQuizRepository Quizzes { get; }
        IAssignmentRepository Assignments { get; }
        IEnrollmentRepository Enrollments { get; }
        IAdminRepository Admins { get; } // Updated to reflect the corrected naming
        IStudentRepository Students { get; } // Added for Student repository
        IInstructorRepository Instructors { get; } // Added for Instructor repository

        Task<int> CompleteAsync(); // Method to save changes to the database
    }
}
