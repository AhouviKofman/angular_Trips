﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dto.classes
{
    public partial class User
    {
        public short IdUser { get; set; }

        public string? UserFirstName { get; set; }

        public string? UserLastName { get; set; }

        public string? UserPhone { get; set; }

        public string? UserMail { get; set; }

        public string? UserPassword { get; set; }

        public bool? UserFirstAid { get; set; }
    }



}
