using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class Entrega
{
    public int Id { get; set; }
    public string PlacaCarro { get; set; }
    public CodigoInterno CodigoInterno { get; set; }
    public int PesoEntrada { get; set; }
    public int PesoSaida { get; set; }
    public int IdTransponder {get; set; }
    public int IdTransportadora {get; set; }
    public int IdResponsavelBosch {get; set; }
 
    public Transponder Transponder {get; set; }
    public Transportadora Transportadora {get; set; }
    public ResponsavelBosch ResponsavelBosch {get; set; }
    

    public virtual List<EntregaEntregador> EntregaEntregadorList { get; set; }

    public Entrega()
    {
        EntregaEntregadorList = new List<EntregaEntregador>();
    }


    public void Salvar()
    {
        using(var context = new Context())
        {
            context.Add(this);
            context.SaveChanges();
        }
    }

    public void Deletar()
    {
        using(var context = new Context())
        {
            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Entrega FindById(int Id)
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == Id);

            return entrega;
        }
    }

    public void Update()
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == this.Id);

            entrega.PlacaCarro = this.PlacaCarro;
            entrega.CodigoInterno = this.CodigoInterno;
            entrega.PesoEntrada = this.PesoEntrada;
            entrega.PesoSaida = this.PesoSaida;
            entrega.Transponder = this.Transponder;
            entrega.Transportadora = this.Transportadora;
            entrega.ResponsavelBosch = this.ResponsavelBosch;


            context.SaveChanges();
        }
    }
}
