using System.ComponentModel.DataAnnotations;

namespace EmployeesManagement.Models
{
    public class DtoEmployee
    {
        [Required]
        public int CompanyId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DeletedOn { get; set; }
        [Required]
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Lastlogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int PortalId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public string Telephone { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Username { get; set; }

    }
}
