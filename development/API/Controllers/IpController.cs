using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using Model;
using DTO;

namespace Controllers;

[Route("[controller]")]
public class IpController : ControllerBase
{
    public IConfiguration _configuration; //add

    public IpController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("BuscarId/{id}")]
    public Object BuscarPorId(int id)
    {  
        try{
            var ip = Model.Ip.BuscarPorId(id);
            return new{
                EnderecoIp = ip.EnderecoIp,
                Adm = ip.Adm
            };
        }catch(Exception e){
            return new{
                Resposta = "Ip não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Buscar por Endereco
    [HttpGet]
    [Route("BuscarEndereco/{endereco}")]
    public Object BuscarPorEndereco(string endereco)
    {  
        try{
            var ip = Model.Ip.BuscarPorEndereco(endereco);
            return new{
                EnderecoIp = ip.EnderecoIp,
                Adm = ip.Adm
            };
        }catch(Exception e){
            return new{
                Resposta = "Ip não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Buscar todos
    [HttpGet]
    [Route("BuscarTodos")]
    public Object BuscarTodos()
    {  
        try{
            List<Tuple<string,bool>> ip = Model.Ip.BuscarTodos();
            return ip.Select(x => new{
                enderecoIp = x.Item1,
                adm = x.Item2
            });

        }catch(Exception e){
            return new{
                Resposta = "Nenhum endereco IP encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] IpDTO ipDTO)
    {  
        try{
            Ip ip = new Ip(ipDTO);
            ip.Salvar();
            return new{
                Resposta = "Ip cadastrado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar ip",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar/{enderecoIp}")]
    public Object Editar(string enderecoIp)
    {  
       try{
            Model.Ip.Editar(enderecoIp);
            return new{
                Resposta = "Ip editado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar Ip",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Deletar por ID
    [HttpDelete]
    [Route("DeletarId/{id}")]
    public Object DeletarId(int id)
    {  
        try{
            Ip ip = Model.Ip.BuscarPorId(id);
            ip.DeletarPorId();
            return new{
                Resposta = "Ip deletado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar ip",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Deletar por EnderecoIP
    [HttpDelete]
    [Route("DeletarEndereco/{endereco}")]
    public Object DeletarEndereco(string endereco)
    {  
        try{
            Ip ip = Model.Ip.BuscarPorEndereco(endereco);
            ip.DeletarPorEndereco();

            return new{
                Resposta = "Ip deletado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar ip",
                Erro = e.Message
            };
        }
    }
}