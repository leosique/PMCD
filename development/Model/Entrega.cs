using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DTO;
namespace Model;

public partial class Entrega
{
    public int Id { get; set; }
    public string PlacaCarro { get; set; }
    public CodigoInterno CodigoInterno { get; set; }
    public int PesoEntrada { get; set; }
    public int PesoSaida { get; set; }
    public DateTime? DataEntrega {get; set; }
    public Boolean? Liberado {get; set; }
    public int? IdTransponder {get; set; }
    public int? IdTransportadora {get; set; }
    public int? IdResponsavelBosch {get; set; }
 
    public Transponder Transponder {get; set; }
    public Transportadora Transportadora {get; set; }
    public ResponsavelBosch ResponsavelBosch {get; set; }
    

    public virtual List<EntregaEntregador> EntregaEntregadorList { get; set; }

    public Entrega()
    {
        EntregaEntregadorList = new List<EntregaEntregador>();
    }

    public Entrega(EntregaDTO entregaDTO){
        this.Id = entregaDTO.Id;
        this.PlacaCarro = entregaDTO.PlacaCarro;
        this.CodigoInterno = (CodigoInterno) entregaDTO.CodigoInterno;
        this.PesoEntrada = entregaDTO.PesoEntrada;
        this.PesoSaida = entregaDTO.PesoSaida;
        this.DataEntrega = entregaDTO.DataEntrega;
        this.Liberado = entregaDTO.Liberado;
        this.IdTransponder = entregaDTO.IdTransponder;
        this.IdTransportadora = entregaDTO.IdTransportadora;
        this.IdResponsavelBosch = entregaDTO.IdResponsavelBosch;
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
            var entregaEntregador = context.EntregasEntregadores.Where(e => e.IdEntrega == this.Id).ToList();

            if (entregaEntregador != null){
                foreach(EntregaEntregador x in entregaEntregador){
                    context.Remove(x);
                }
            }

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Entrega BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            Entrega entrega = context.Entregas.FirstOrDefault(e => e.Id == Id);
            return entrega;
        }
    }

    public static List<Entrega> BuscarAprovadas()
    {
        using(var context = new Context())
        {
            List<Entrega> entregas = context.Entregas.Where(e => e.Liberado == true).ToList();

            return entregas;
        }
    }

    public static List<Entrega> BuscarPendentes()
    {
        using(var context = new Context())
        {
            List<Entrega> entregas = context.Entregas.Where(e => e.Liberado == false).ToList();

            return entregas;
        }
    }

    public void Editar()
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


    public void EditarPlaca()
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == this.Id);

            entrega.PlacaCarro = this.PlacaCarro;

            context.SaveChanges();
        }
    }

    public void EditarPesoEntrada()
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == this.Id);

            entrega.PesoEntrada = this.PesoEntrada;

            context.SaveChanges();
        }
    }

    public void EditarPesoSaida()
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == this.Id);

            entrega.PesoSaida = this.PesoSaida;

            context.SaveChanges();
        }
    }

    public void EditarTransponder()
    {
        using(var context = new Context())
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.Id == this.Id);

            entrega.IdTransponder = this.IdTransponder;

            context.SaveChanges();
        }
    }
}
