using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Models.Entities
{
    public class Form
    {
        public long FormID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}