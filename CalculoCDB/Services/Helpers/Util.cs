using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class Util
    {
		public static decimal ObterCDI()
		{
			// Lógica para obter o valor da CDI do último mês         
			return 0.009m;
		}


		public static decimal ObterTaxaBanco()
		{
			// Lógica para obter o valor da TB          
			return 1.08m;
		}
	}
}
