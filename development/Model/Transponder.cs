using System;
using System.Collections.Generic;

namespace Model;

public partial class Transponder
{

    public int Id { get; set; }
    public string Codigo { get; set; }

    public virtual List<Entrega> EntregaList { get; set; }

    public Transponder()
    {
        EntregaList = new List<Entrega>();
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

    public static Transponder FindById(int Id)
    {
        using(var context = new Context())
        {
            var transponder = context.Transponders.FirstOrDefault(e => e.Id == Id);

            return transponder;
        }
    }

    public void Update()
    {
        using(var context = new Context())
        {
            var transponder = context.Transponders.FirstOrDefault(e => e.Id == this.Id);

            transponder.Codigo = this.Codigo;

            context.SaveChanges();
        }
    }
}
