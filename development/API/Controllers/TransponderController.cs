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
    public Object BuscarPorId(int id)
    {  
        try{
            var trans = Model.Transponder.BuscarPorId(id);
            return new{
                Codigo = trans.Codigo
            };
        }catch{
            return new{
                Resposta = "Transponder não encontrado"
            };
        }
    }

    //* ------------------------------------------------ Buscar por Codigo
    [HttpGet]
    [Route("BuscarCodigo/{codigo}")]
    public Object BuscarPorCodigo(string codigo)
    {  
        try{
            var trans = Model.Transponder.BuscarPorCodigo(codigo);
            return new{
                Id = trans.Id
            };
        }catch{
            return new{
                Resposta = "Transponder não encontrado"
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] TransponderDTO transDTO)
    {  
        try{
            Transponder trans = new Transponder(transDTO);
            trans.Salvar();
            return new{
                Resposta = "Transponder cadastrado com sucesso",
                Id = trans.Id
            };
        }catch{
            return new{
                Resposta = "Erro ao cadastrar transponder"
            };
        }
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public Object Editar([FromBody] TransponderDTO transDTO)
    {  
       try{
            Transponder trans = new Transponder(transDTO);
            trans.Editar();
            return new{
                Resposta = "Transponder editado com sucesso",
            };
        }catch{
            return new{
                Resposta = "Erro ao editar transponder"
            };
        }
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    public Object Deletar(int id)
    {  
        try{
            Transponder trans = Model.Transponder.BuscarPorId(id);
            trans.Deletar();
            return new{
                Resposta = "Transponder deletado com sucesso"
            };
        }catch{
            return new{
                Resposta = "Erro ao deletar transponder"
            };
        }
    }
}