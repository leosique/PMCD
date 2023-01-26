using System;
using System.Collections.Generic;
using DTO;
namespace Model;

public partial class Entregador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Cnh { get; set; }
    public string Rg { get; set; }
    public string DataNascimento { get; set; }



    public virtual List<EntregaEntregador> EntregaEntregadorList { get; set; }

    public Entregador()
    {
        EntregaEntregadorList = new List<EntregaEntregador>();
    }

    public Entregador(EntregadorDTO entregadorDTO)
    {
        this.Id = entregadorDTO.Id;
        this.Nome = entregadorDTO.Nome;
        this.Cpf = entregadorDTO.Cpf;
        this.Rg = entregadorDTO.Rg;
        this.Cnh = entregadorDTO.Cnh;
        this.DataNascimento = entregadorDTO.DataNascimento;
        this.EntregaEntregadorList = new List<EntregaEntregador>();
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
             var entregaEntregador = context.EntregasEntregadores.Where(e => e.IdEntregador == this.Id).ToList();

            if (entregaEntregador != null){
                foreach(EntregaEntregador x in entregaEntregador){
                    context.Remove(x);
                }
            }
            else{
                throw new ArgumentException("Não foi possível deletar.");
            }

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Entregador BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
          
            var entregador = context.Entregadores.FirstOrDefault(e => e.Id == Id);

            if(entregador != null)
                return entregador;
            throw new ArgumentException("Não foi possível encontrar o entregador.");
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            Entregador entregador = context.Entregadores.FirstOrDefault(e => e.Id == this.Id);
            if(entregador == null)
                throw new ArgumentException("Não foi possível encontrar o entregador.");
            

            entregador.Nome = this.Nome;
            entregador.Cpf = this.Cpf;
            entregador.Cnh = this.Cnh;
            entregador.Rg = this.Rg;
            entregador.DataNascimento = this.DataNascimento;

            
            context.SaveChanges();
        }
    }
}
