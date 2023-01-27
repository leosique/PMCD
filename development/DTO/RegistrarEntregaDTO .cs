using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DTO;

public class RegistrarEntregaDTO 
{
    public int Id { get; set; }
    public string? DataEntrega {get; set; }
    public Boolean? Liberado {get; set; }
    public string? NotaFiscal { get; set; }
    public int? IdTransportadora {get; set; }

}
