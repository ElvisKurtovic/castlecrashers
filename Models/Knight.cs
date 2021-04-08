namespace castlecrashers.Models
{
    public class Knight
    {
        public Knight()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int CastleId { get; set; }

        // //you only need to add this if you are trying to populate
        public Castle Castle { get; set; }
    }
}