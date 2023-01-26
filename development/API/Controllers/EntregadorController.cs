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
public class EntregadorController : ControllerBase
{
    public IConfiguration _configuration; //add

    public EntregadorController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("Buscar/{id}")]
    public object BuscarPorId(int id)
    {  
        try{
            Entregador entregador = Model.Entregador.BuscarPorId(id);
            
            return new{
                Nome = entregador.Nome,
                Cpf = entregador.Cpf,
                Cnh = entregador.Cnh,
                Rg = entregador.Rg,
                DataNascimento = entregador.DataNascimento
            };
        }catch(Exception e){
            return new{
                Resposta = "Entregador não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public object Salvar([FromBody] EntregadorDTO entregadorDTO)
    {  
        try{
            Entregador entregador = new Entregador(entregadorDTO);
            entregador.Salvar();

            return new{
                Resposta = "Entregador cadastrado com sucesso",
                Id = entregador.Id
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar entregador",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public object Editar([FromBody] EntregadorDTO entregadorDTO)
    {
        try{
            Entregador entregador = new Entregador(entregadorDTO);
            
            entregador.Editar();
         
            return new{
                Resposta = "Entregador editado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar entregador",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public object Deletar(int id)
    {  
        try{
            Entregador entregador = Model.Entregador.BuscarPorId(id);

            entregador.Deletar();

            return new{
                Resposta = "Entregador deletado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar entregador",
                Erro = e.Message
            };
        }
        
    }
}