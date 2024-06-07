using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string? Title { get; set; }
        [Required]
        [StringLength(200)]
        public string? Author { get; set; }
        public DateTime? PublishDate { get; set; }
        public Category Category { get; set; }
    }
}
