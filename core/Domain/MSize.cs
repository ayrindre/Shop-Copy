using System;
using System.ComponentModel.DataAnnotations;
namespace core.Domain
{
    public class MSize
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "نباید بدون مفدار باشد")]
        public string Size { get; set; }
        [Required(ErrorMessage = "نباید بدون مفدار باشد")]
        public int IdProduct { get; set; }
    }
}