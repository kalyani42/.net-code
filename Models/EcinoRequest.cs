using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GetECIno.Models
{
    public class EcinoRequest
    {
        [Required]
        public string Name { get; set; }
        [RegularExpression("male|female| ' '",ErrorMessage ="The gender must be 'male' or 'female' only.")]
        public string Gender { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})$",ErrorMessage ="Date must be in format of YYYY/mm/DD")]
        
        public string Dob { get; set; }

    }
}
