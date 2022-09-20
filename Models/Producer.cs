namespace School_Library.Models
{
    public class Producer 
    {
        public int ProducerID { get; set; }
        public string NameProducer { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
