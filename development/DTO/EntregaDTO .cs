using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DTO;

public class EntregaDTO 
{
    public int Id { get; set; }
    public string PlacaCarro { get; set; }
    public int CodigoInterno { get; set; }
    public int PesoEntrada { get; set; }
    public int PesoSaida { get; set; }
    public DateTime? DataEntrega {get; set; }
    public Boolean? Liberado {get; set; }
    public int? IdTransponder {get; set; }
    public int? IdTransportadora {get; set; }
    public int? IdResponsavelBosch {get; set; }

}
