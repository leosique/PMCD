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
public class EntregaController : ControllerBase
{
    public IConfiguration _configuration; //add

    public EntregaController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por id
    [HttpGet]
    [Route("Buscar/{id}")]
    public Entrega BuscarPorId(int id)
    {  
        var entrega = Model.Entrega.BuscarPorId(id);
        return entrega;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] Entrega entrega)
    {  
        entrega.Salvar();
        return "Entrega cadastrada com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] Entrega entrega)
    {  
        entrega.Editar();
        return "Entrega editada com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar")]
    public string Deletar([FromBody] Entrega entrega)
    {  
        entrega.Deletar();
        return "Entrega deletada com sucesso";
    }

    
}
