﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    interface ILoginModel
    {
        Users LoginMethod(string login, string password);
    }
}
