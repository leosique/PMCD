using System;
using System.Collections.Generic;

namespace Model;

public partial class Transportadora
{
    public Transportadora()
    {
        EntregasFeitas = new HashSet<Entrega>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }


    public virtual ICollection<Entrega> EntregasFeitas { get; set; }


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

    public static Transportadora FindById(int Id)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Id == Id);

            return transportadora;
        }
    }

    public void Update()
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Id == this.Id);

            transportadora.Nome = this.Nome;
            transportadora.Cnpj = this.Cnpj;


            context.SaveChanges();
        }
    }
}
