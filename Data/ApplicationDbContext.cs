using DEPI_E_Learning.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DEPI_E_Learning.ApplicationDbContexts
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many relationship between Instructor and Course
            modelBuilder.Entity<CourseModel>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Define the relationship between Course and Session
            modelBuilder.Entity<SessionModel>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between Session and Module
            modelBuilder.Entity<ModuleModel>()
                .HasOne(m => m.Session)
                .WithMany(s => s.Modules)
                .HasForeignKey(m => m.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Module and Quiz
            modelBuilder.Entity<QuizModel>()
                .HasOne(q => q.Module)
                .WithMany(m => m.Quizzes)
                .HasForeignKey(q => q.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Quiz and Question
            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Question and Answer
            modelBuilder.Entity<AnswerModel>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Module and Assignment
            modelBuilder.Entity<AssignmentModel>()
                .HasOne(a => a.Module)
                .WithMany(m => m.Assignments)
                .HasForeignKey(a => a.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Student and Enrollment
            modelBuilder.Entity<EnrollmentModel>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Course and Enrollment
            modelBuilder.Entity<SessionModel>()
                .HasOne(e => e.Course)
                .WithMany(c =>c.Sessions)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Assignment and Submission
            modelBuilder.Entity<SubmissionModel>()
                .HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Student and Submission
            modelBuilder.Entity<SubmissionModel>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Submissions)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {
            
        }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<ModuleModel> Modules { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<QuizModel> Quizzes { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<SubmissionModel> Submissions { get; set; }
        public DbSet<SessionModel>  Sessions { get; set; }
    }
}
