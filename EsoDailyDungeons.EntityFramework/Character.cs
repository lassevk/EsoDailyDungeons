namespace EsoDailyDungeons.EntityFramework
{
    public class Character
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        public string? Name { get; set; }
        public DateTime LastRewardsObtainedAt { get; set; }
    }
}