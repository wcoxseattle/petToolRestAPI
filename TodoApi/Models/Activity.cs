namespace PetToolAPI.Models
{
    public class Activity
    {
        public long Id { get; set; }
        public long ActivityTypeId { get; set; }
        public long FoodId { get; set; }
        public long ToyId { get; set; }
        public string? Notes { get; set; }
        public long FlagId { get; set; }

    }
}
