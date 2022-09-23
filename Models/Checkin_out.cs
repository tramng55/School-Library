﻿namespace School_Library.Models
{
    public class Checkin_out 
    {
        public int StudentID { get; set; }
        public int StaffID { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public Student Student { get; set; }
        public Staff Staff { get; set; }

    }
}
