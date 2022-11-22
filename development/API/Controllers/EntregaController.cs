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
        try{
            
            Entrega entrega = Model.Entrega.BuscarPorId(id);

            return new{
                PlacaCarro = entrega.PlacaCarro,
                CodigoInterno = ((CodigoInterno)entrega.CodigoInterno).ToString(),
                PesoEntrada = entrega.PesoEntrada,
                PesoSaida = entrega.PesoSaida,
                DataEntrega = entrega.DataEntrega,
                Liberado = entrega.Liberado,
                IdTransponder = entrega.IdTransponder,
                IdTransportadora = entrega.IdTransportadora,
                IdResponsavelBosch = entrega.IdResponsavelBosch,
            };
        }catch(Exception e){
            return new{
                Resposta = "Entrega não encontrada",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.Salvar();
            return new{
                Resposta = "Entrega cadastrada com sucesso",
                Id = entrega.Id
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar entrega",
                Erro = e.Message
            };
        }   
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public Object Editar([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.Editar();
            return new{
                Resposta = "Entrega editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar entrega",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Editar Placa
    [HttpPut]
    [Route("Editar/Placa")]
    public Object EditarPlaca([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.EditarPlaca();
            return new{
                Resposta = "Placa editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar placa",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Editar Peso Entrada
    [HttpPut]
    [Route("Editar/PesoEntrada")]
    public Object EditarPesoEntrada([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.EditarPesoEntrada();
            return new{
                Resposta = "Peso de entrada editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar peso de entrada",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Editar Peso Saida
    [HttpPut]
    [Route("Editar/PesoSaida")]
    public Object EditarPesoSaida([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.EditarPesoSaida();
            return new{
                Resposta = "Peso de saída editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar peso de saída",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Editar Transponder
    [HttpPut]
    [Route("Editar/Transponder")]
    public Object EditarTransponder([FromBody] EntregaDTO entregaDTO)
    {  
        try{
            Entrega entrega = new Model.Entrega(entregaDTO);
            entrega.EditarTransponder();
            return new{
                Resposta = "Transponder editada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar transponder",
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
            Entrega entrega = Model.Entrega.BuscarPorId(id);
            entrega.Deletar();
            return new{
                Resposta = "Entrega deletada com sucesso"
                };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar entrega",
                Erro = e.Message
            };
        }
        
    }    
}