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
public class TransponderController : ControllerBase
{
    public IConfiguration _configuration; //add

    public TransponderController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("Buscar/{id}")]
    public Transponder BuscarPorId(int id)
    {  
        var trans = Model.Transponder.BuscarPorId(id);
        return trans;
    }

    //* ------------------------------------------------ Buscar por Codigo
    [HttpGet]
    [Route("BuscarCodigo/{codigo}")]
    public Transponder BuscarPorCodigo(string codigo)
    {  
        var trans = Model.Transponder.BuscarPorCodigo(codigo);
        return trans;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] Transponder trans)
    {  
        trans.Salvar();
        return "Transponder cadastrado com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] Transponder trans)
    {  
        trans.Editar();
        return "Transponder editado com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public string Deletar(int id)
    {  
        Transponder trans = Model.Transponder.BuscarPorId(id);
        trans.Deletar();
        return "Transponder deletado com sucesso";
    }
}