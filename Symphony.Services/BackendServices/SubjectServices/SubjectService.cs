using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly SymphonyDBContext _context;

        public SubjectService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<SubjectVM> GetSubjectVMAsync(int id)
        {
            var _subject = await _context.Subjects
                .Include(x => x.Files)
                .Include(x => x.Images)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (_subject is null) return null;

            return _subject.AsVM();
        }

        public async Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync()
        {
            var subjects = await _context.Subjects
                .Include(x => x.Files)
                .Include(x => x.Images)
                .Select(s => s.AsVM())
                .ToListAsync();
            return subjects;
        }

        public async Task<SimpleSubjectVM> CreateSubjectVMAsync(SubjectCreateRequest createRequest)
        {
            var timeNow = DateTime.Now;
            var _subject = new Subject()
            {
                Name = createRequest.Name,
                Description = createRequest.Description,
                Duration = createRequest.Duration,
                Price = createRequest.Price,
                CreatedAt = timeNow,
                UpdatedAt = timeNow,
                IsShown = true
            };

            await _context.Subjects.AddAsync(_subject);
            await _context.SaveChangesAsync();

            var image = new Image()
            {
                Path = @"images\defaultSubject.jpg",
                SubjectId = _subject.Id
            };

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            var _created_subject = await _context.Subjects
                                    .SingleOrDefaultAsync(x => x.Id == _subject.Id);

            return _created_subject.AsSimpleVM();
        }

        public async Task ChangeSubjectState(int id)
        {
            var _subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            var status = _subject.IsShown;

            if (_subject.IsShown == false)
            {
                _subject.IsShown = true;
            }
            else _subject.IsShown = false;

            await _context.SaveChangesAsync();
        }

        public async Task<SimpleSubjectVM> UpdateSubjectVMAsync(SubjectUpdateRequest subjectVM)
        {
            var _subject = await _context.Subjects
                .Include(x => x.Images)
                .Include(x => x.Files)
                .FirstOrDefaultAsync(x => x.Id == subjectVM.Id);

            if (_subject is null) return null;
            _subject.Name = subjectVM.Name;
            _subject.Description = subjectVM.Description;
            _subject.Duration = subjectVM.Duration;
            _subject.Price = subjectVM.Price;
            _subject.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _subject.AsSimpleVM();
        }

        public async Task<SimpleSubjectVM> UpdateSubjectImageVMAsync(int id, List<IFormFile> images)
        {
            var subject = await _context.Subjects
                .Include(s => s.Images)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject is null) return null;

            if (images is not null)
            {
                if (subject.Images is not null)
                {
                    _context.Images.RemoveRange(subject.Images);
                }
                await AddImages(images, subject.Id);
            }

            return subject.AsSimpleVM();
        }
        
        public async Task<SimpleSubjectVM> UpdateSubjectFileVMAsync(int id, List<IFormFile> files)
        {
            var subject = await _context.Subjects
                .Include(s => s.Files)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject is null) return null;

            if (files is not null)
            {
                if (subject.Files is not null)
                {
                    _context.Files.RemoveRange(subject.Files);
                }

                await AddAttachments(files, subject.Id);
            }

            return subject.AsSimpleVM();
        }

        private async Task AddImages(List<IFormFile> images, int subjectId)
        {
            foreach (var image in images)
            {
                string curTime = DateTime.Now.ToString("MMddyyyyHHmmss");
                var imgName = curTime + "_" + Path.GetFileName(image.FileName);
                var imgPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", imgName);
                await using (var fileStream = new FileStream(imgPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                var _image = new Image
                {
                    Path = @$"images\{imgName}",
                    SubjectId = subjectId
                };
                await _context.Images.AddAsync(_image);
            }
            await _context.SaveChangesAsync();
        }

        private async Task AddAttachments(List<IFormFile> attachments, int subjectId)
        {
            foreach (var attachment in attachments)
            {
                string curTime = DateTime.Now.ToString("MMddyyyyHHmmss");
                var orgFileNam = Path.GetFileName(attachment.FileName);
                var fileName = curTime + "_" + orgFileNam;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", fileName);
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await attachment.CopyToAsync(fileStream);
                }

                var _file = new Symphony.Data.Entities.File
                {
                    Path = @$"files\{fileName}",
                    FileName = orgFileNam,
                    SubjectId = subjectId
                };
                await _context.Files.AddAsync(_file);
            }
            await _context.SaveChangesAsync();
        }
    }
}