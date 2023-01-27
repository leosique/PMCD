using System;
using System.Collections.Generic;
using DTO;
using System.Security.Cryptography;

namespace Model;

public partial class Transportadora
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Senha {get; set; }
    public bool PrimeiroAcesso {get; set;}

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
            this.PrimeiroAcesso = true;
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

            if(transportadora == null)
                throw new ArgumentException("O CNPJ nao pode ser encontrado.");
            return transportadora;
        }
    }

    public static Transportadora BuscarPorCNPJ(string cnpj)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Cnpj == cnpj);

            if(transportadora == null)
                throw new ArgumentException("O CNPJ nao pode ser encontrado.");
            return transportadora;
        }
    }

    public bool Verifica(string senha){
        using(var context = new Context()){
            if(senha != this.Senha)
                throw new ArgumentException("Senha incompativel");
        }
        
       return this.PrimeiroAcesso;
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Id == this.Id);
            if(transportadora == null)
                throw new ArgumentException("O CNPJ nao pode ser encontrado.");

            transportadora.Nome = this.Nome;
            transportadora.Cnpj = this.Cnpj;
            transportadora.Senha = this.Senha;

            context.SaveChanges();
        }
    }

    public void EditarPrimeiroAcesso(string senhaNova)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Cnpj == this.Cnpj);
            if(transportadora == null)
                throw new ArgumentException("O CNPJ nao pode ser encontrado.");

            if(this.Senha == transportadora.Senha && transportadora.PrimeiroAcesso){
                transportadora.Senha = senhaNova;
                transportadora.PrimeiroAcesso = false;
            }else{
                throw new ArgumentException("Senha antiga incorreta");
            }

            context.SaveChanges();
        }
    }

    public static Transportadora Login(TransLoginDTO transloginDTO)
    {
        using(var context = new Context())
        {
            var transportadora = context.Transportadoras.FirstOrDefault(e => e.Cnpj == transloginDTO.Cnpj && e.Senha == transloginDTO.Senha);
            if(transportadora == null)
                throw new ArgumentException("O CNPJ nao pode ser encontrado.");

            return transportadora;
        }
    }

    public string GeraSenha(){
        byte[] senha = new byte[6];
        Random r = new Random();
        r.NextBytes(senha);
        string novaSenha = Convert.ToBase64String(senha);
        this.Senha = novaSenha;
        Salvar();
        
        return novaSenha;
    }
}