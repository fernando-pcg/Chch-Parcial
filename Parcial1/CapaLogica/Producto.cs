using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
	public class Producto
	{
		public string nombre { get; set; }
		public string descripcion { get; set; }
		public string existencia { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public DateTime fechaCreacion { get; set; }
		public string marca { get; set; }
		public string categoria { get; set; }
		public int estado { get; set; }
	}
}
