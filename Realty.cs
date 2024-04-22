﻿using System.ComponentModel.DataAnnotations;

namespace DB_993
{
    public class Realty
    {
        [Key]
        public int Id { get; set; }
        public string? NameRealty { get; set; }
        public string? PhotoRealty { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public int Square { get; set; }
        public int Floor { get; set; }
        public int Mark { get; set; }
        public int Rooms { get; set; }
        public string? City { get; set; }
        public string? Type { get; set; }
        public string? ForWhat { get; set; }

    }
}
