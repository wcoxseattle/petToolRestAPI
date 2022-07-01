namespace PetToolAPI.Models
{

    public class Pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public long pet_type_id { get; set; }
        public DateOnly? date_of_birth { get; set; } //? Means this is Nullable
        public DateTime created_on { get; set; }
        public DateTime? modified_on { get; set; }  //Optional
    }
}
