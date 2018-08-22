using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKCard
    {
        public int CardID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string FlavorText { get; set; }
    }
}
