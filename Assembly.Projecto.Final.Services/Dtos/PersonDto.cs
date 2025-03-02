

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class PersonDto
    {
        public NameDto Name { get; set; } = new();
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhotoFileName { get; set; }
        public bool IsActive { get; set; }
    }
}
