using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DTO;

public class EntregaEntregadorDTO 
{
    public int Id { get; set; }
    public int IdEntrega {get; set; }
    public int IdEntregador {get; set; }
    public bool Motorista {get; set;}

}
