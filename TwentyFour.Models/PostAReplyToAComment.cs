using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class PostAReplyToAComment
    {
        public string Text { get; set; }
        public Guid Author { get; set; }
    }
}
