using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICDBService
    {
        Task<decimal> CalcularCDBInvestimento(InvestimentCDBModel investimentCDBModel);
    }
}
