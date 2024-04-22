﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DB_993
{
    internal class Compilation
    {
        public int Id { get; set; }
        public int Id_Realty { get; set; }
        [ForeignKey("ReltyInIdCom")]
        public Realty? Realty_id { get; set; }
    }
}
