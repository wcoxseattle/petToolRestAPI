namespace TodoApi.Models
{
    public class Visit
    {
        public long id { get; set; }
        public long pet_id { get; set; }
        public long person_id { get; set; }
        public long activity_id { get; set; }
        public DateTime created_on { get; set; }
    }
}
