using System;
using System.Collections.Generic;
using DTO;
namespace Model;

public partial class Ip
{

    public int Id { get; set; }
    public string EnderecoIp { get; set; }


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
            context.Remove(this);
            context.SaveChanges();
        }
    }

    public void DeletarPorId()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.Where(e => e.Id == this.Id);            
            context.Remove(this);
            context.SaveChanges();
        }
    }

    public static Ip BuscarPorId(int Id)
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.Id == Id);

            return ip;
        }
    }

    public static Ip BuscarPorEndereco(string enderecoIp)
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.EnderecoIp == enderecoIp);

            return ip;
        }
    }

    public static List<string> BuscarTodos()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.Select(x => x.EnderecoIp).ToList();

            return ip;
        }
    }

    public void Editar()
    {
        using(var context = new Context())
        {
            var ip = context.Ips.FirstOrDefault(e => e.Id == this.Id);

            ip.EnderecoIp = this.EnderecoIp;

            context.SaveChanges();
        }
    }
}
