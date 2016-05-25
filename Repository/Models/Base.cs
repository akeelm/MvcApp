using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    /// <summary>
    /// By using this base class for most models, we don't have to keep recreating the same properties.
    /// The defaults ensure logic doesn't get missed when creating new objects.
    /// </summary>
    public abstract class Base
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public bool Deleted { get; set; } = false;
    }
}
