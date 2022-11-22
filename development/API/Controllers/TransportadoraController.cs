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
using API.Services;
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
    [Authorize]
    public Object BuscarPorId(int id)
    {  
        try{
            Transportadora trans = Model.Transportadora.BuscarPorId(id);
            return new{
                Id = trans.Id,
                Nome = trans.Nome,
                Cnpj = trans.Cnpj,
                Senha = trans.Senha
            };
        }catch(Exception e){
            return new{
                Resposta = "Transportadora não encontrada",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Buscar por CPNJ
    [HttpGet]
    [Route("BuscarCNPJ/{cpnj}")]
    public Object BuscarPorId(string cnpj)
    {  
        try{
            Transportadora trans = Model.Transportadora.BuscarPorCNPJ(cnpj);
            return new{
                Id = trans.Id,
                Nome = trans.Nome,
                Cnpj = trans.Cnpj,
                Senha = trans.Senha
            };
        }catch(Exception e){
            return new{
                Resposta = "Transportadora não encontrada",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Criar
    [HttpPost]
    [Route("Salvar")]
    public Object Salvar([FromBody] TransportadoraDTO transDTO)
    {  
        try{
            Transportadora trans = new Transportadora(transDTO);
            trans.Salvar();
            return new{
                Resposta = "Transportadora cadastrada com sucesso",
                Id = trans.Id
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao cadastrar transportadora",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    public Object Editar([FromBody] TransportadoraDTO transDTO)
    {  
        try{
            Transportadora trans = new Transportadora(transDTO);
            trans.Editar();
            return new{
                Resposta = "Transportadora editada com sucesso",
                Id = trans.Id
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao editar transportadora",
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
            Transportadora trans = Model.Transportadora.BuscarPorId(id);
            trans.Deletar();
            return new{
                Resposta = "Transportadora deletada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao deletar transportadora",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Testando Login
    [HttpPost]
    [Route("Login")]
    public Object LoginAsync([FromBody] TransLoginDTO transLoginDTO){


        Transportadora trans = Transportadora.Login(transLoginDTO);

        if(trans != null){

            var token = TokenService.GenerateToken(trans);

            return new{
                transportadora = trans,
                token = token
            };
        }else{
            return new{
                Resposta = "Erro em login",
            };
        }
        

    }
}