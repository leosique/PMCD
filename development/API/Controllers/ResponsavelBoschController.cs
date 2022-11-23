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
    public Object BuscarPorId(int id)
    {  
        try{
            ResponsavelBosch rp = Model.ResponsavelBosch.BuscarPorId(id);

            return new{
                Id = rp.Id,
                Nome = rp.Nome,
                Documento = rp.Documento,
                Edv = rp.Edv
            };
        }catch(Exception e){
            return new{
                Resposta = "ResponsavelBosch não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Buscar por EDV
    [HttpGet]
    [Route("BuscarEDV/{edv}")]
    public Object BuscarPorEdv(string edv)
    {  
        try{
            ResponsavelBosch rp = Model.ResponsavelBosch.BuscarPorEdv(edv);

            return new{
                Id = rp.Id,
                Nome = rp.Nome,
                Documento = rp.Documento,
                Edv = rp.Edv
            };
        }catch(Exception e){
            return new{
                Resposta = "ResponsavelBosch não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Buscar por Documento
    [HttpGet]
    [Route("BuscarDoc/{doc}")]
    public Object BuscarPorDoc(string doc)
    {  
        try{
            ResponsavelBosch rp = Model.ResponsavelBosch.BuscarPorDoc(doc);

            return new{
                Id = rp.Id,
                Nome = rp.Nome,
                Documento = rp.Documento,
                Edv = rp.Edv
            };
        }catch(Exception e){
            return new{
                Resposta = "Responsavel Bosch não encontrado",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] ResponsavelBoschDTO rpDTO)
    {  
        try{
            ResponsavelBosch rp = new ResponsavelBosch(rpDTO);
            rp.Salvar();
            return new{
                Resposta = "Responsavel Bosch cadastrado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar Responsavel Bosch",
                Erro = e.Message
            };
        }
        
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public Object Editar([FromBody] ResponsavelBoschDTO rpDTO)
    {  
        try{
            ResponsavelBosch rp = new ResponsavelBosch(rpDTO);
            rp.Editar();
            return new{
                Resposta = "Responsavel Bosch editado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar Respondavel Bosch",
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
            ResponsavelBosch rp = Model.ResponsavelBosch.BuscarPorId(id);
            rp.Deletar();
            return new{
                Resposta = "Responsavel Bosch deletado com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar responsavel Bosch",
                Erro = e.Message
            };
        }
    }
}