﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkiraEntity.Entity
{
    public class User
    {
        public int user_id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public DateTime creation_date { get; set; }

    }
}
