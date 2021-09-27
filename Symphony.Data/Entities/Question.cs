using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Question_Text { get; set; }
        public int Opt1_key { get; set; }
        public string Opt1_value { get; set; }
        public int Opt2_key { get; set; }
        public string Opt2_value { get; set; }
        public int Opt3_key { get; set; }
        public string Opt3_value { get; set; }
        public int Opt4_key { get; set; }
        public string Opt4_value { get; set; }
        public int Valid_Opt_key { get; set; }
        public int Score { get; set; }
        public int SubjectId { get; set; }
        public bool? IsDelete { get; set; }
        public Subject Subject { get; set; }
        public List<QuestionExam> QuestionExams { get; set; }
        public List<Student_Answer> Student_Answers { get; set; }
    }
}