namespace DatingApp.Models
{
    public class UniversityAttendance
    {
        public string UserId { get; set; }
        public string UniversityId { get; set; }
        public bool? IsGraduated { get; set; }
        public string FieldOfStudy { get; set; }

        public virtual University University { get; set; }
        public virtual User User { get; set; }
    }
}