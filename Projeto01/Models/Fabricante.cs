using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto01.Models
{
    public class Fabricante
    {
        public long FabricanteId { get; set; }
        public string Nome { get; set;  }

        public virtual ICollection<Produto> Produtos { get; set; }

        /**
         * 'virtual' é uma palavra-chave	usada para modificar
         * uma declaração de metodo, propriedade, indexador ou
         * evento, e permirtir que ele seja sobrescrito em uma 
         * classe derivada
         */

        /**
         * A escolha da	interface
         * ICollection para	uma	propriedade	se deve	ao fato de que,	
         * com esta	 interface,	 seja possível iterar (navegar)	nos         * objetos recuperados e modificá-los.	
         */

    }
}