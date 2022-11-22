using System;
using System.Collections.Generic;
using DTO;

namespace Model;

public partial class EntregaEntregador
{

    public int Id { get; set; }
    public int IdEntrega {get; set; }
    public int IdEntregador {get; set; }
    public bool Motorista {get; set;}

    public Entrega Entrega {get; set; }
    public Entregador Entregador {get; set; }

    

    public EntregaEntregador(EntregaEntregadorDTO entregaEntregadorDTO){
        this.Id = entregaEntregadorDTO.Id;
        this.IdEntrega = entregaEntregadorDTO.IdEntrega;
        this.IdEntregador = entregaEntregadorDTO.IdEntregador;
        this.Motorista = entregaEntregadorDTO.Motorista;
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

    public static EntregaEntregador BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var entregaEntregador = context.EntregasEntregadores.FirstOrDefault(e => e.Id == Id);

            return entregaEntregador;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var entregaEntregador = context.EntregasEntregadores.FirstOrDefault(e => e.Id == this.Id);

            entregaEntregador.Entrega = this.Entrega;
            entregaEntregador.Entregador = this.Entregador;
            entregaEntregador.Motorista = this.Motorista;
            

            context.SaveChanges();
        }
    }
}
