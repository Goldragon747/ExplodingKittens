using System;
using System.Collections.Generic;
using System.Text;

namespace ExpKittensDAL
{
    public class HandModelList
    {
        public List<Hand> HandList { get; set; }
        public HandModelList()
        {
            HandList = new List<Hand>();
        }
    }
}
