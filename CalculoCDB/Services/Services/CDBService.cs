using Services.Interfaces;
using Services.Models;
using System;
using System.Threading.Tasks;

namespace Services
{
	public class CDBService : ICDBService
	{
		public async Task<decimal> CalcularCDBInvestimento(InvestimentCDBModel investimentCDBModel)
		{
			decimal valorBruto = investimentCDBModel.amount;
			decimal valorLiquido = investimentCDBModel.amount;

			for (int i = 1; i <= investimentCDBModel.months; i++)
			{
                decimal cdi = Util.ObterCDI();
				decimal valorBrutoMes = valorBruto * (1 + (cdi * Util.ObterTaxaBanco()));
				valorBruto = valorBrutoMes;
			}
			valorLiquido = await CalcularValorLiquido(valorBruto, investimentCDBModel.months);

			return Math.Round(valorLiquido, 2); 
		}


		private async Task<decimal> CalcularValorLiquido(decimal valor, int prazoEmMeses)
		{
            decimal taxaImposto;
            if (prazoEmMeses <= 6)
			{
				taxaImposto = 0.225m;
			}
			else if (prazoEmMeses <= 12)
			{
				taxaImposto = 0.20m;
			}
			else if (prazoEmMeses <= 24)
			{
				taxaImposto = 0.175m;
			}
			else
			{
				taxaImposto = 0.15m;
			}

			decimal valorImposto = valor * taxaImposto;
			decimal valorLiquido = valor - valorImposto;

			return valorLiquido;


		}
	}
}
