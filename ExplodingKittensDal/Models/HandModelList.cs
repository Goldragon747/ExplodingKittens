using System;
using System.Collections.Generic;
using System.Text;

namespace ExplodingKittensDal.Models
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
