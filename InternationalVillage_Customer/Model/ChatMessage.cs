﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Model
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime Time { get; set; }
        public string Picture { get; set; }
        public bool IsOriginNative { get; set; }
    }
}
