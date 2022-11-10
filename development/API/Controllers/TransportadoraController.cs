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
public class TransportadoraController : ControllerBase
{
    public IConfiguration _configuration; //add

    public TransportadoraController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("Buscar/{id}")]
    public Object BuscarPorId(int id)
    {  
        var trans = Model.Transportadora.BuscarPorId(id);
        return trans;
    }

    //* ------------------------------------------------ Buscar por CPNJ
    [HttpGet]
    [Route("BuscarCNPJ/{cpnj}")]
    public Object BuscarPorId(string cnpj)
    {  
        var trans = Model.Transportadora.BuscarPorCNPJ(cnpj);
        return trans;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] Transponder trans)
    {  
        trans.Salvar();
        return "Transportadora cadastrada com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] Transponder trans)
    {  
        trans.Editar();
        return "Transportadora editada com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar")]
    public string Deletar([FromBody] Transponder trans)
    {  
        trans.Deletar();
        return "Transportadora deletada com sucesso";
    }
}