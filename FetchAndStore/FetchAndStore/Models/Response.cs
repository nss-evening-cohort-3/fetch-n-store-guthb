using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FetchAndStore.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string StatusCode { get; set; }
        [Required]
        public string Method { get; set; }
        [Required]
        public string RequestTime { get; set; }
        
    }
}