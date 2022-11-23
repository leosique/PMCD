using System;
using System.Collections.Generic;
using DTO;

namespace Model;

public partial class Transportadora
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Senha {get; set; }


    public virtual List<Entrega> EntregaList { get; set; }

    public Transportadora()
    {
        EntregaList = new List<Entrega>();
    }

    public Transportadora(TransportadoraDTO transDTO){
        this.Id = transDTO.Id;
        this.Nome = transDTO.Nome;
        this.Cnpj = transDTO.Cnpj;
        this.Senha = transDTO.Senha;
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
            var entrega = context.Entregas.Where(e => e.IdTransportadora == this.Id).ToList();

            if (entrega != null){
                foreach(Entrega x in entrega){
                    x.IdTransportadora = null;
                }
            }

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Transportadora BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            Console.WriteLine(Id);
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Id == Id);
            Console.WriteLine(transportadora.Cnpj);
            return transportadora;
        }
    }

    public static Transportadora BuscarPorCNPJ(string cnpj)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Cnpj == cnpj);

            return transportadora;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Id == this.Id);

            transportadora.Nome = this.Nome;
            transportadora.Cnpj = this.Cnpj;
            transportadora.Senha = this.Senha;

            context.SaveChanges();
        }
    }

    public static Transportadora Login(TransLoginDTO transloginDTO)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Cnpj == transloginDTO.Cnpj && e.Senha == transloginDTO.Senha);

            return transportadora;
        }
    }
}
