namespace School_Library.Models.BookViewModel
{
    public class CreatCheckin_outBookViewModel
    {
        public int StudentID { get; set; }
        public int StaffID { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
