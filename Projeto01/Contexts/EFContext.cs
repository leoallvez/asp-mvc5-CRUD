using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Projeto01.Models;
using System.Data.Entity;
/**
 * Para	 que nossa aplicação possa se beneficiar do Entity Framework,	
 * é preciso que ele acesse	a base de dados	por	meio de	um
 * contexto, que representar uma sessão de interação a aplicação
 * com a base de dados, seja para consulta ou atualização. Para o EF,
 * um contexto é uma classe que estende System.Data.Entity.DbContext.
*/
namespace Projeto01.Contexts
{
    public class EFContext : DbContext
    {
        /**("Asp_Net_MVC_CS") é uma	 string	 enviada como argumento.
        argumento refere-se ao  nome de  uma Connection   String*/

        //Note que o construtor estende a execução do construtor da  classe	 base.
        public EFContext() : base("Asp_Net_MVC_CS") {}

        /**
         * DbSet
         * representam entidades (Entity) que são utilizadas 
         * para as operações de	criação, leitura,
         * atualização e remoção de objetos.
         */
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
 