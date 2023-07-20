using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetECIno.Models;
namespace GetECINo.Repository
{
   public interface IDataRepository
    {
        ActionResult GetEcino(EcinoRequest ecinoRequest);
        Task<bool> IsAliveAsync();
    }
}
