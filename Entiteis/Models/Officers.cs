﻿using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
    public class Officers
    {
        public int Id { get; set; }

        public OfficerRole Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
