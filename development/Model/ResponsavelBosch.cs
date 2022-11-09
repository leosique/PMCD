using System;
using System.Collections.Generic;

namespace Model;

public partial class ResponsavelBosch
{
   

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string Edv { get; set; }


    public virtual List<Entrega> EntregaList { get; set; }

    public ResponsavelBosch()
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

    public static ResponsavelBosch BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Id == Id);

            return responsavelBosch;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Id == this.Id);

            responsavelBosch.Nome = this.Nome;
            responsavelBosch.Documento = this.Documento;
            responsavelBosch.Edv = this.Edv;

            context.SaveChanges();
        }
    }
}
