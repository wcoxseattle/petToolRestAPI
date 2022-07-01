namespace PetToolAPI.Models
{

    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PetTypeId { get; set; }
        public DateOnly? DateOfBirth { get; set; } //? Means this is Nullable
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }  //Optional
    }
}
