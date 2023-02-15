namespace DogApi.DAL.Entities
{
    public class DogEntity
    {
        public DogEntity(Guid guiId, string name, string? breed, DateTime birthDate)
        {
            GuiId = guiId;
            Name = name;
            Breed = breed;
            BirthDate = birthDate;
        }

        public Guid GuiId { get; set; }

        public string Name { get; set; }

        public string? Breed { get; set; }
        
        public DateTime BirthDate { get; set;}
    }
}
