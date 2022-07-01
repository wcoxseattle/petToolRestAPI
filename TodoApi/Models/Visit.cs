namespace PetToolAPI.Models
{
    public class Visit
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public long PersonId { get; set; }
        public long ActivityId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
