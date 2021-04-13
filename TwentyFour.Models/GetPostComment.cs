using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class GetPostComment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public Guid Author { get; set; }
    }
}
