using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
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

        public async Task<SubjectVM> CreateSubjectVMAsync(SubjectCreateRequest createRequest)
        {
            var _subject = new Subject()
            {
                Name = createRequest.Name,
                Description = createRequest.Description,
                Duration = createRequest.Duration,
                Price = createRequest.Price,
                CreatedAt = DateTime.Now,
                IsShown = true
            };

            await _context.Subjects.AddAsync(_subject);
            await _context.SaveChangesAsync();

            if (createRequest.images is not null)
            {
                foreach (var image in createRequest.images)
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
                        Path = imgPath,
                        SubjectId = _subject.Id
                    };
                    await _context.Images.AddAsync(_image);
                }
                await _context.SaveChangesAsync();
            }
            if (createRequest.attachments is not null)
            {
                foreach (var attachment in createRequest.attachments)
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
                        Path = filePath,
                        FileName = orgFileNam,
                        SubjectId = _subject.Id
                    };
                    await _context.Files.AddAsync(_file);
                }
                await _context.SaveChangesAsync();
            }

            var _subjectVM = new SubjectVM();
            return _subjectVM;
        }

        public Task DeleteSubjectVMAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectVM> GetSubjectVMAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectVM> UpdateSubjectVMAsync(SubjectVM subjectVM)
        {
            throw new NotImplementedException();
        }
    }
}