﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_MarketX.Data.Exceptions
{
    public class CorreoEnUsoException : Exception
    {
        public CorreoEnUsoException(string message) : base(message) { }
    }
}
