﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenProvider.TokenAuthentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
