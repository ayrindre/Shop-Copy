using System;
using System.ComponentModel.DataAnnotations;

namespace infrastructure.Data.Entities
{
    public class Size
    {
        public int Id { get; set; }

        public string size { get; set; }

        public int IdProduct { get; set; }
    }
}