using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employe.Core.BundleEmployee.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DeletedOn { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Lastlogin { get; set; }

        public string Password { get; set; }
        public int PortalId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string Telephone { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
        public string Username { get; set; }
    
        }
}
