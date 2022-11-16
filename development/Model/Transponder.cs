using System;
using System.Collections.Generic;
using DTO;
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

    public Transponder(TransponderDTO transponderDTO){
        this.Id = transponderDTO.Id;
        this.Codigo = transponderDTO.Codigo;
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
            var entrega = context.Entregas.Where(e => e.IdTransponder == this.Id).ToList();

            if (entrega != null){
                foreach(Entrega x in entrega){
                    x.IdTransponder = null;
                }
            }

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Transponder BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var transponder = context.Transponders.FirstOrDefault(e => e.Id == Id);

            return transponder;
        }
    }

    public static Transponder BuscarPorCodigo(string cod)
    {
        using(var context = new Context())
        {
            var transponder = context.Transponders.FirstOrDefault(e => e.Codigo == cod);

            return transponder;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var transponder = context.Transponders.FirstOrDefault(e => e.Id == this.Id);

            transponder.Codigo = this.Codigo;

            context.SaveChanges();
        }
    }
}
