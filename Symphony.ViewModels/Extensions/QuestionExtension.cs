using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class QuestionExtension
    {
        public static QuestionVM AsVM(this Question question) => new QuestionVM
        {
            Id = question.Id,
            Question_Text = question.Question_Text,
            Opt1_value = question.Opt1_value,
            Opt2_value = question.Opt2_value,
            Opt3_value = question.Opt3_value,
            Opt4_value = question.Opt4_value,
            Valid_Opt_key = question.Valid_Opt_key,
            Score = question.Score,
            SubjectId = question.SubjectId
        };
    }
}