using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class ExamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BatchId { get; set; }
        public int SubjectId { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEntranceExam { get; set; }
        public int CourseId { get; set; }
        public int Duration { get; set; }
        public BatchVM Batch { get; set; }
        public SubjectVM Subject { get; set; }
        public CourseVM Course { get; set; }
        public List<Student_In_Exam> Student_In_Exams { get; set; }
        public List<Exam_Result> Exam_Results { get; set; }
        public List<QuestionExam> QuestionExams { get; set; }
        public List<Student_Answer> Student_Answers { get; set; }
        public List<ExamRegistration> ExamRegistrations { get; set; }
    }
}