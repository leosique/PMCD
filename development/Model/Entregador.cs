using System;
using System.Collections.Generic;

namespace Model;

public partial class Entregador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string DataNascimento { get; set; }



    public virtual List<EntregaEntregador> EntregaEntregadorList { get; set; }

    public Entregador()
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

    public static Entregador FindById(int Id)
    {
        using(var context = new Context())
        {
            var entregador = context.Entregadores.FirstOrDefault(e => e.Id == Id);

            return entregador;
        }
    }

    public void Update()
    {
        using(var context = new Context())
        {
            var entregador = context.Entregadores.FirstOrDefault(e => e.Id == this.Id);

            entregador.Nome = this.Nome;
            entregador.Documento = this.Documento;
            entregador.DataNascimento = this.DataNascimento;

            context.SaveChanges();
        }
    }
}
