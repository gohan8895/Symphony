namespace Symphony.ViewModels.VMs
{
    public class QuestionVM
    {
        public int Id { get; set; }
        public string Question_Text { get; set; }
        public string Opt1_value { get; set; }
        public string Opt2_value { get; set; }
        public string Opt3_value { get; set; }
        public string Opt4_value { get; set; }
        public int Valid_Opt_key { get; set; }
        public int Score { get; set; }
        public int SubjectId { get; set; }
    }

    public class QuestionCreateRequest
    {
        public string Question_Text { get; set; }
        public string Opt1_value { get; set; }
        public string Opt2_value { get; set; }
        public string Opt3_value { get; set; }
        public string Opt4_value { get; set; }
        public int Valid_Opt_key { get; set; }
        public int Score { get; set; }
        public int SubjectId { get; set; }
    }
}