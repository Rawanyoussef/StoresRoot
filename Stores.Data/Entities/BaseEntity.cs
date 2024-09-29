using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Data.Entities
{
    public class BaseEntity<T>
    {
          
        public int Id { get; set; }
        public DateTime createdAt { get; set; }

    }
}
