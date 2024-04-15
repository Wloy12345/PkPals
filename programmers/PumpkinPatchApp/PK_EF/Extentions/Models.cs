using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_EF.Extentions
{
        public class ContactModels
        {
          
            public string FirstName { get; set; }
            public string Subject { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Message { get; set; }
        }
    
}
