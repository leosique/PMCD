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
public class ResponsavelBoschController : ControllerBase
{
    public IConfiguration _configuration; //add

    public ResponsavelBoschController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por ID
    [HttpGet]
    [Route("Buscar/{id}")]
    public ResponsavelBosch BuscarPorId(int id)
    {  
        var rp = Model.ResponsavelBosch.BuscarPorId(id);
        return rp;
    }

    //* ------------------------------------------------ Buscar por EDV
    [HttpGet]
    [Route("BuscarEDV/{edv}")]
    public ResponsavelBosch BuscarPorId(string edv)
    {  
        var rp = Model.ResponsavelBosch.BuscarPorEdv(edv);
        return rp;
    }

    //* ------------------------------------------------ Buscar por Documento
    [HttpGet]
    [Route("BuscarDoc/{doc}")]
    public ResponsavelBosch BuscarPorDoc(string doc)
    {  
        var rp = Model.ResponsavelBosch.BuscarPorDoc(doc);
        return rp;
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public string Salvar([FromBody] ResponsavelBosch rp)
    {  
        rp.Salvar();
        return "Responsavel Bosch cadastrado com sucesso";
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public string Editar([FromBody] ResponsavelBosch rp)
    {  
        rp.Editar();
        return "Responsavel Bosch editado com sucesso";
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public string Deletar(int id)
    {  
        ResponsavelBosch rp = Model.ResponsavelBosch.BuscarPorId(id);
        rp.Deletar();
        return "Responsavel Bosch deletado com sucesso";
    }
}