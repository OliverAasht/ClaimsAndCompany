using System.ComponentModel.DataAnnotations;

namespace ClaimsAndCompany.Domain.Entities
{
    public enum ClaimType
    {
        MedicalCheckup,
        DentalTreatment
    }

    public class ClaimEntity
    {
        public string UCR { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CompanyId must be greater than 0.")]
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        [Required]
        public string AssuredName { get; set; }
        public int IncurredLoss { get; set; }
        public int Closed { get; set; }
    }
}
