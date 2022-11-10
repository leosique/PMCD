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
    public Entregador BuscarPorId(int id)
    {  
        var entregador = Model.Entregador.BuscarPorId(id);
        return entregador;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] Entregador entregador)
    {  
        entregador.Salvar();
        return "Entregador cadastrado com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] Entregador entregador)
    {  
        entregador.Editar();
        return "Entregador editado com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar")]
    public string Deletar([FromBody] Entregador entregador)
    {  
        entregador.Deletar();
        return "Entregador deletado com sucesso";
    }
}