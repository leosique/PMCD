using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DTO;

public class TransportadoraDTO 
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Senha {get; set; }
    public bool PrimeiroAcesso {get; set; }
}
