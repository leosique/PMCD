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
public class EntregaEntregadorController : ControllerBase
{
    public IConfiguration _configuration; //add

    public EntregaEntregadorController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("Buscar/{id}")]
    public EntregaEntregador BuscarPorId(int id)
    {  
        var entregaEntregador = Model.EntregaEntregador.BuscarPorId(id);
        return entregaEntregador;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] EntregaEntregador entregaEntregador)
    {  
        entregaEntregador.Salvar();
        return "Entrega Entregador cadastrada com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] EntregaEntregador entregaEntregador)
    {  
        entregaEntregador.Editar();
        return "Entrega Entregador editada com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public string Deletar(int id)
    {  
        EntregaEntregador entregaEntregador = Model.EntregaEntregador.BuscarPorId(id);
        entregaEntregador.Deletar();
        return "Entrega Entregador deletada com sucesso";
    }
}