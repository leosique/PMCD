using System;
using System.Collections.Generic;
using DTO;
using System.Net;
namespace Model;

public partial class Ip
{

    public int Id { get; set; }
    public string EnderecoIp { get; set; }
    public bool Adm {get;set;}


    public Ip(IpDTO ipDTO){
        this.EnderecoIp = ipDTO.EnderecoIp;
        this.Adm = (bool)ipDTO.Adm;
    }

    public Ip()
    {
        
    }

    public void Salvar()
    {
        using(var context = new Context())
        {
            Console.WriteLine(this.Adm);
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

    public static bool VerificaIp(){
        string enderecoIp = GetIp();
        
        using(var context = new Context()){
            var ip = context.Ips.FirstOrDefault(e => e.EnderecoIp == enderecoIp);
            
            if(ip != null)
                return ip.Adm;
            throw new ArgumentException("Não foi possível encontrar o Ip");
        }
    }

    public static string GetIp(){
        string nomeMaquina = Dns.GetHostName();
        IPAddress[] ipLocal = Dns.GetHostAddresses(nomeMaquina);
        Console.WriteLine(nomeMaquina);
        string ip = ipLocal[3].ToString(); //[0] é IPv6 [3] é IPv4

        for (int i = 0; i < ipLocal.Length; i++)
        {
            Console.WriteLine("IP Address {0}: {1} ", i, ipLocal[i].ToString());
        }

        return ip;
    }
}