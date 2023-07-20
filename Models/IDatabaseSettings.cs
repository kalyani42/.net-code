using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetECINo.Models
{
    interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}
