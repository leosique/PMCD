using System;
using System.Collections.Generic;
using DTO;

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

    public ResponsavelBosch(ResponsavelBoschDTO rpDTO){
        this.Id = rpDTO.Id;
        this.Nome = rpDTO.Nome;
        this.Documento = rpDTO.Documento;
        this.Edv = rpDTO.Edv;
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
            var entrega = context.Entregas.Where(e => e.IdResponsavelBosch == this.Id).ToList();

            if (entrega != null){
                foreach(Entrega x in entrega){
                    x.IdResponsavelBosch = null;
                }
            }
            else{
                throw new ArgumentException("Não foi possivel deletar.");
            }

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static ResponsavelBosch BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Id == Id);

            if(responsavelBosch != null)
                return responsavelBosch;
            throw new ArgumentException("Não foi possível encontrar o responsável Bosch.");
        }
    }

    public static ResponsavelBosch BuscarPorEdv(string Edv)
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Edv == Edv);

            if(responsavelBosch != null)
                return responsavelBosch;
            throw new ArgumentException("Não foi possível encontrar o responsável Bosch.");
        }
    }

    public static ResponsavelBosch BuscarPorDoc(string Doc)
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Documento == Doc);

            if(responsavelBosch != null)
                return responsavelBosch;
            throw new ArgumentException("Não foi possível encontrar o responsável Bosch.");
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var responsavelBosch = context.ResponsaveisBosch.FirstOrDefault(e => e.Id == this.Id);

            if(responsavelBosch == null)
                throw new ArgumentException("Não foi possível encontrar o responsável Bosch.");

            responsavelBosch.Nome = this.Nome;
            responsavelBosch.Documento = this.Documento;
            responsavelBosch.Edv = this.Edv;

            context.SaveChanges();
        }
    }
}
