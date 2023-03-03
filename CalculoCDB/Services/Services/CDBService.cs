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
			decimal valorInvestido = investimentCDBModel.ValorInicial;
			decimal valorBruto = investimentCDBModel.ValorInicial;
			decimal valorLiquido = investimentCDBModel.ValorInicial;

			for (int i = 1; i <= investimentCDBModel.PrazoMeses; i++)
			{
                decimal cdi = Util.ObterCDI();
				decimal valorBrutoMes = valorInvestido * (1 + (cdi * Util.ObterTaxaBanco()));
				decimal valorLiquidoMes = await CalcularValorLiquido(valorBrutoMes, i);
				valorBruto += valorBrutoMes;
				valorLiquido += valorLiquidoMes;
				valorInvestido = valorLiquidoMes;
			}
			return valorLiquido;
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
