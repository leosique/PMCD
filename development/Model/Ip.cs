using System;
using System.Collections.Generic;
using DTO;
namespace Model;

public partial class Ip
{

    public int Id { get; set; }
    public string EnderecoIp { get; set; }
    public bool Adm {get;set;}


    public Ip(IpDTO ipDTO){
        this.Id = ipDTO.Id;
        this.EnderecoIp = ipDTO.EnderecoIp;
    }

    public Ip()
    {
        
    }

    public void Salvar()
    {
        using(var context = new Context())
        {
            context.Add(this);
            context.SaveChanges();
        }
    }

    public void DeletarPorEndereco()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.Where(e => e.EnderecoIp == this.EnderecoIp);     

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o endereco IP");
       
            context.Remove(this);
            context.SaveChanges();
        }
    }

    public void DeletarPorId()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.Where(e => e.Id == this.Id);

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o ID");

            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Ip BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.Id == Id);

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o ID");

            return ip;
        }
    }

    public static Ip BuscarPorEndereco(string enderecoIp)
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.EnderecoIp == enderecoIp);

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o endereco IP");

            return ip;
        }
    }

    public static List<T> thisIsAtest<T>()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.Select(x => x.EnderecoIp).ToList();
        
            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o endereco IP");

            return ip;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.Id == this.Id);

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o ID");

            ip.EnderecoIp = this.EnderecoIp;

            context.SaveChanges();
        }
    }
}
