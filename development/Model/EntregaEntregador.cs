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

    public EntregaEntregador(){
    }

    public EntregaEntregador(EntregaEntregadorDTO entregaEntregadorDTO){
        this.Id = entregaEntregadorDTO.Id;
        this.IdEntrega = entregaEntregadorDTO.IdEntrega;
        this.IdEntregador = entregaEntregadorDTO.IdEntregador;
        this.Motorista = entregaEntregadorDTO.Motorista;
    }

    public static List<EntregaEntregador> BuscarAprovadas()
    {
        using(var context = new Context())
        {
            List<EntregaEntregador> entregas = context.EntregasEntregadores
                .Join(context.Entregas, e => e.IdEntrega, i => i.Id, (e, i) => new EntregaEntregador
                {
                    Id = e.Id,
                    IdEntregador = e.Entregador.Id,
                    Motorista = e.Motorista,
                    Entrega = i,                    
                })
                .Join(context.Entregadores, e => e.IdEntregador, i => i.Id, (e, i) => new EntregaEntregador
                {
                    Id = e.Id,
                    Motorista = e.Motorista,
                    Entrega = e.Entrega,
                    Entregador = i,
                })
                .Where(e => e.Entrega.Liberado == true)
                .ToList();

            return entregas;
        }
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
