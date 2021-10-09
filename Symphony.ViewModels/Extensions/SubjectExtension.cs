using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class SubjectExtension
    {
        public static SubjectVM AsVM(this Subject subject) => new SubjectVM
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            Duration = subject.Duration,
            Price = subject.Price,
            IsShown = subject.IsShown,
            Images = subject.Images.Select(image => new ImageVM
            {
                Path = image.Path
            }).ToList(),
            Files = subject.Files.Select(file => new FileVM
            {
                FileName = file.FileName,
                Path = file.Path
            }).ToList(),
        };

        public static SimpleSubjectVM AsSimpleVM(this Subject subject) => new SimpleSubjectVM
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            Duration = subject.Duration,
            Price = subject.Price
        };
    }
}