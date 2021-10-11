using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.ExamRegistrationServices
{
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly SymphonyDBContext _context;

        public ExamRegistrationService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationbyExamIdAsync(int examId)
        {
            var _regs = await _context.ExamRegistrations
                .Include(x => x.AppUser)
                .Where(x => x.ExamId == examId)
                .ToListAsync();

            if (_regs is null) return null;
            return _regs.Select(x => x.AsVM());
        }

        public async Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationsAsync()
        {
            var _regs = await _context.ExamRegistrations
                .Include(x => x.AppUser)
                .Select(x => x.AsVM()).ToListAsync();
            return _regs;
        }

        public async Task<IEnumerable<ExamRegistrationVM>> CreateExamRegistrationAsync(ExamRegistrationCreateRequest request)
        {
            //checking if examregistration already exists
            var _existingRegis = await _context.ExamRegistrations
                .Include(x => x.AppUser)
                .Where(x => x.ExamId == request.ExamId)
                .ToListAsync();
            if (_existingRegis.Count > 0) return null;

            if (request.excelsheet is not null)
            {
                var _regs = await AddStudentIdFromExcelSheet(request.excelsheet, request.ExamId);
                return _regs;
            }
            return null;
        }

        public async Task<int> UpdateExamRegistraion(ExamRegistrationUpdateRequest request)
        {
            //var _existingRegis = await _context.ExamRegistrations
            //    .Include(x => x.AppUser)
            //    .Where(x => x.ExamId == request.ExamId)
            //    .ToListAsync();
            //var _student_in_exams = await _context.Student_In_Exams.Where(x => x.ExamId == request.ExamId).ToListAsync();
            //_context.Student_In_Exams.RemoveRange(_student_in_exams);
            //_context.ExamRegistrations.RemoveRange(_existingRegis);

            await DeleteExamRegistraionAsync(request.ExamId);

            await _context.SaveChangesAsync();

            if (request.excelsheet is not null)
            {
                var _regs = await AddStudentIdFromExcelSheet(request.excelsheet, request.ExamId);
                return 1;
            }
            return 0;
        }

        private async Task<IEnumerable<ExamRegistrationVM>> AddStudentIdFromExcelSheet(IFormFile excelsheet, int examId)
        {
            var timeNow = DateTime.Now;

            var file = excelsheet;
            var registrations = new List<ExamRegistration>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        registrations.Add(new ExamRegistration()
                        {
                            UserId = Guid.Parse(worksheet.Cells[row, 1].Value.ToString().Trim()),
                            ExamId = examId,
                            IsDelete = false,
                            CreateAt = timeNow
                        });
                    }
                }

                await _context.ExamRegistrations.AddRangeAsync(registrations);
                await _context.SaveChangesAsync();
            }

            var _createdRegis = await GetExamRegistrationbyExamIdAsync(examId);
            foreach (var item in _createdRegis)
            {
                var _student_exam = new Student_In_Exam
                {
                    ExamId = item.ExamId,
                    UserId = item.UserId
                };
                await _context.Student_In_Exams.AddAsync(_student_exam);
            }

            await _context.SaveChangesAsync();

            return _createdRegis;
        }

        public async Task<int> DeleteExamRegistraionAsync(int examId)
        {
            var _existingRegis = await _context.ExamRegistrations
                .Include(x => x.AppUser)
                .Where(x => x.ExamId == examId)
                .ToListAsync();
            var _student_in_exams = await _context.Student_In_Exams.Where(x => x.ExamId == examId).ToListAsync();
            _context.Student_In_Exams.RemoveRange(_student_in_exams);
            _context.ExamRegistrations.RemoveRange(_existingRegis);

            return await _context.SaveChangesAsync();
        }
    }
}