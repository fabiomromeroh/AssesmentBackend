using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class UserTask
    {
        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool Checked { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
