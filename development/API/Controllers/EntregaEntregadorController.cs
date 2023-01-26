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
    public Object BuscarPorId(int id)
    {  
        try{
            EntregaEntregador entregaEntregador = Model.EntregaEntregador.BuscarPorId(id);

            return new{
                Id = entregaEntregador.Id,
                IdEntrega = entregaEntregador.IdEntrega,
                IdEntregador = entregaEntregador.IdEntregador,
                Motorista = entregaEntregador.Motorista
            };
        }catch(Exception e){
            return new{
                Resposta = "Entrega-Entregador não encontrado",
                Erro = e.Message
            };
        }
        
  
    }

    [HttpGet]
    [Route("Aprovadas")]
    public IActionResult BuscarAprovadas()
    {

        List<EntregaEntregador> entregas = Model.EntregaEntregador.BuscarAprovadas();

        var output = entregas.Select(e => new
        {
            Id = e.Id,
            Entrega = e.Entrega,
            Entregador = e.Entregador
        });

        return Ok(output);
    }

    
    [HttpGet]
    [Route("Transportadoras/{cnpj}")]
    public IActionResult BuscarTransportadoras(string cnpj)
    {

        List<EntregaEntregador> entregas = Model.EntregaEntregador.BuscarTransportadora(cnpj);

        var output = entregas.Select(e => new
        {
            Id = e.Id,
            Entrega = e.Entrega,
            Entregador = e.Entregador
        });

        return Ok(output);
    }

    [HttpGet]
    [Route("Pendentes")]
    public IActionResult BuscarPendentes()
    {

        List<EntregaEntregador> entregas = Model.EntregaEntregador.BuscarPendentes();

        var output = entregas.Select(e => new
        {
            Id = e.Id,
            Entrega = e.Entrega,
            Entregador = e.Entregador
        });

        return Ok(output);
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] EntregaEntregadorDTO entregaEntregadorDTO)
    {  
        try{
            EntregaEntregador entregaEntregador = new Model.EntregaEntregador(entregaEntregadorDTO);
            entregaEntregador.Salvar();
            return new{
                Resposta = "Entrega-Entregador cadastrada com sucesso",
                Id = entregaEntregador.Id
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar entrega-Entregador",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public Object Editar([FromBody] EntregaEntregadorDTO entregaEntregadorDTO)
    {  
        try{
            EntregaEntregador entregaEntregador = new EntregaEntregador(entregaEntregadorDTO);
            entregaEntregador.Editar();
            return new{
                Resposta = "Entrega-Entregador editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar entrega-Entregador",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public Object Deletar(int id)
    {  
        try{
            EntregaEntregador entregaEntregador = Model.EntregaEntregador.BuscarPorId(id);
            entregaEntregador.Deletar();
            return new{
                Resposta = "Entrega-Entregador deletada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar entrega-Entregador",
                Erro = e.Message
            };
        }
        
    }
}