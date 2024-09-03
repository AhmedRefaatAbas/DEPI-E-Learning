using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class StudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentModel?> GetStudentByIdAsync(int studentId)
        {
            return await _unitOfWork.Students.GetByIdAsync(studentId);
        }

        public async Task<StudentModel?> GetStudentByEmailAsync(string email)
        {
            return await _unitOfWork.Students.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task AddStudentAsync(StudentModel student)
        {
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateStudentAsync(StudentModel student)
        {
            _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await _unitOfWork.Students.DeleteAsync(studentId);
            await _unitOfWork.CompleteAsync();
        }
    }
}
