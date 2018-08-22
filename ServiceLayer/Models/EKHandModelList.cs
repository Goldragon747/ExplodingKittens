using ExpKittensDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKHandModelList
    {
        public List<Hand> HandList { get; set; }
        public EKHandModelList()
        {
            HandList = new List<Hand>();
        }
    }
}
