﻿using HepsiWebAPI.Domain.Common;
using System.Reflection.Metadata.Ecma335;

namespace HepsiWebAPI.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand(){}

        public Brand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }   
    }
}
