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

    public static List<Tuple<string, bool>> BuscarTodos()
    {
        using(var context = new Context())
        {
            var ip = context.Ips
            .Select(x => new Tuple<string, bool>(x.EnderecoIp, x.Adm))
            .ToList();
        
            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o endereco IP");

            return ip;
        }
    }

    public static void Editar(string endereco)
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.EnderecoIp == endereco);

            if(ip == null)
                throw new ArgumentException("Não foi possível encontrar o Ip");

            ip.Adm = !ip.Adm;

            context.SaveChanges();
        }
    }
}
