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
            var entregador = Model.Entregador.BuscarPorId(id);

            return new{
                Nome = entregador.Nome,
                Documento = entregador.Documento,
                DataNascimento = entregador.DataNascimento
            };
        }catch{
            return new{
                Erro = "Entregador não encontrado"
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public object Salvar([FromBody] Entregador entregador)
    {  
        entregador.Salvar();

        return new{
            Resposta = "Entregador cadastrado com sucesso"
        };
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public object Editar([FromBody] Entregador entregador)
    {  
        
        entregador.Editar();

        return new{
            Resposta = "Entregador editado com sucesso"
        };
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public object Deletar(int id)
    {  
        Entregador entregador = Model.Entregador.BuscarPorId(id);
        entregador.Deletar();

        return new{
            Resposta = "Entregador deletado com sucesso"
        };
    }
}