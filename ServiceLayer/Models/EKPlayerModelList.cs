﻿using ExpKittensDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKPlayerModelList
    {
        public List<Player> PlayerList { get; set; }
        public EKPlayerModelList()
        {
            PlayerList = new List<Player>();
        }
    }
}