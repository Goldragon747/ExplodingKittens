﻿using ExplodingKittensDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKCardModelList
    {
        public List<Card> CardList { get; set; }

        public EKCardModelList()
        {
            CardList = new List<Card>();
        }
    }
}