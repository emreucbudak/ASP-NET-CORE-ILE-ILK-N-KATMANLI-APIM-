using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public record ProductDtoForUpdate
    {
        public int ID { get; init; }
        public string ProductName { get; init; }
        public int CategoryID { get; init; }
    }
}
