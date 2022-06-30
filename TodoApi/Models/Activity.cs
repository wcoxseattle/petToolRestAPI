namespace TodoApi.Models
{
    public class Activity
    {
        public long id { get; set; }
        public long activity_type_id { get; set; }
        public long food_id { get; set; }
        public long toy_id { get; set; }
        public string? notes { get; set; }
        public long flag_id { get; set; }

    }
}
