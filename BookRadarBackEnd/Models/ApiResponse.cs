namespace BookRadarBackEnd.Models
{
    public class Books
    {
        public List<string> alternate_names { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public List<string> top_subjects { get; set; }
        public string top_work { get; set; }
        public string type { get; set; }
        public int work_count { get; set; }
        public double ratings_average { get; set; }
        public double ratings_sortable { get; set; }
        public int ratings_count { get; set; }
        public int ratings_count_1 { get; set; }
        public int ratings_count_2 { get; set; }
        public int ratings_count_3 { get; set; }
        public int ratings_count_4 { get; set; }
        public int ratings_count_5 { get; set; }
        public int want_to_read_count { get; set; }
        public int already_read_count { get; set; }
        public int currently_reading_count { get; set; }
        public int readinglog_count { get; set; }
        public string _version_ { get; set; }
        public string birth_date { get; set; }
        public string death_date { get; set; }
    }
    public class ApiResponseBooks
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public List<Books> docs { get; set; }
    }

}
