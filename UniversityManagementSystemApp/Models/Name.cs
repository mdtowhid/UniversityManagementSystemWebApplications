using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    [Table("Names")]
    public class Name
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

    }
}