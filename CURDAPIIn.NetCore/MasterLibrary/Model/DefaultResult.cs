﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MasterLibrary.Model
{
    public class DefaultResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }
        public string Data { get; set; }
        public int UserId { get; set; }
    }
}
