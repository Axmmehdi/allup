using System.ComponentModel.DataAnnotations;

namespace AllupProjectT.Models
{
    public class Brand :BaseEntity
    {
        [StringLength(255)]
       public string Name { get; set; }
    }
}
