﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskiRS2.MobileApp.Views
{

    public class MainPageMasterMenuItem
    {
        public MainPageMasterMenuItem()
        {
            TargetType = typeof(MainPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}