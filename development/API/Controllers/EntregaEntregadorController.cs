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
        }catch{
            return new{
                Resposta = "EntregaEntregador não encontrado"
            };
        }
        
  
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
                Resposta = "EntregaEntregador cadastrada com sucesso",
                Id = entregaEntregador.Id
            };
        }catch{
            return new{
                Resposta = "Erro ao cadastrar entregaEntregador"
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
                Resposta = "EntregaEntregador editada com sucesso"
            };
        }catch{
            return new{
                Resposta = "Erro ao editar entregaEntregador"
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
                Resposta = "EntregaEntregador deletada com sucesso"
            };
        }catch{
            return new{
                Resposta = "Erro ao deletar entregaEntregador"
            };
        }
        
    }
}