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
    public Object BuscarPorId(int id)
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

    //* ------------------------------------------------ Editar Placa
    [HttpPut]
    [Route("Editar/Placa")]
    public string EditarPlaca([FromBody] Entrega entrega)
    {  
        entrega.EditarPlaca();
        return "Placa editada com sucesso";
    }

    //* ------------------------------------------------ Editar Peso Entrada
    [HttpPut]
    [Route("Editar/PesoEntrada")]
    public string EditarPesoEntrada([FromBody] Entrega entrega)
    {  
        entrega.EditarPesoEntrada();
        return "Peso Entrada editada com sucesso";
    }

    //* ------------------------------------------------ Editar Peso Saida
    [HttpPut]
    [Route("Editar/PesoSaida")]
    public string EditarPesoSaida([FromBody] Entrega entrega)
    {  
        entrega.EditarPesoSaida();
        return "Peso Saida editada com sucesso";
    }

    //* ------------------------------------------------ Editar Transponder
    [HttpPut]
    [Route("Editar/Transponder")]
    public string EditarTransponder([FromBody] Entrega entrega)
    {  
        entrega.EditarTransponder();
        return "Transponder editada com sucesso";
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