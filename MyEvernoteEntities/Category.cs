using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteEntities
{
    [Table("Categories")]
    public class Category : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }

        public virtual List<Note> Notes { get; set; }
        public Category() // fake data ile oluturulurken note gönderirken null hatası vermemesi için.
        {
            Notes = new List<Note>();
        }
    }
}
