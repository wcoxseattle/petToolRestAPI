namespace TodoApi.Models
{
    public class Person
    {
        public long id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string? birth_sex { get; set; }  //Optional
        public string? gender { get; set; } //Optional
        public DateOnly date_of_birth { get; set; }
        public DateTime created_on { get; set; }
        public DateTime? modified_on { get; set; }  //Optional

    }
}
