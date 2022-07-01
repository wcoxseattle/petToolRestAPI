namespace PetToolAPI.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? BirthSex { get; set; }  //Optional
        public string? Gender { get; set; } //Optional
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }  //Optional

    }
}
