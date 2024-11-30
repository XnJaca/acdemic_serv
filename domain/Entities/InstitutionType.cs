using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class InstitutionType
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}