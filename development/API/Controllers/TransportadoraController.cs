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
                Resposta = "Transportadora encontrada",
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

    //* ------------------------------------------------ Buscar por Token
    [HttpGet]
    [Route("BuscarIdToken")]
    [Authorize]
    public Object BuscarIdToken()
    {  
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        string id = "";
        if (identity != null)
        {
            return new{
                Id = identity.FindFirst("Id").Value
            };
        }else{
            return new{
                Resposta = "Id não encontrado"
            };
        }
    }

    //* ------------------------------------------------ Buscar por CPNJ
    [HttpGet]
    [Route("BuscarCNPJ/{cpnj}")]
    [Authorize]
    public Object BuscarPorCNPJ(string cnpj)
    {  
        try{
            Transportadora trans = Model.Transportadora.BuscarPorCNPJ(cnpj);
            return new{
                Resposta = "Transportadora encontrada",
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

    //* ------------------------------------------------ Editar
    [HttpPut]
    [Route("Editar")]
    [Authorize]
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

    //* ------------------------------------------------ Mudar senha ao primeiro acesso
    [HttpPut]
    [Route("EditarPrimeiroAcesso/{senhaNova}")]
    public Object EditarPrimeiroAcesso([FromBody] TransportadoraDTO transDTO, string senhaNova)
    {  
        try{
            Transportadora trans = new Transportadora(transDTO);
            trans.EditarPrimeiroAcesso(senhaNova);
            return new{
                Resposta = "Senha alterada com sucesso"
            };
        }catch(Exception e){
            return new{
                Resposta = "Erro ao alterar a senha",
                Erro = e.Message
            };
        }
    }

    //* ------------------------------------------------ Deletar
    [HttpDelete]
    [Route("Deletar/{id}")]
    [Authorize]
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

    [HttpGet]
    [Route("Verifica")]
    public Object Verifica(string cnpj, string senha){
        try{
            Transportadora trans = Model.Transportadora.BuscarPorCNPJ(cnpj);

            bool v = trans.Verifica(senha);
            return new{
                Resposta = "Sucesso ao verificar primeiro acesso",
                primeiroAcesso = v
            };
        }
        catch(Exception e){
            return new{
                Resposta = "Erro ao verificar se é o primeiro acesso",
                primeiroAcesso = false,
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
                token = "",
                Resposta = "Erro em login",
            };
        }
    }

    [HttpPost]
    [Route("Salvar")]
    public Object GerarSenha([FromBody] TransportadoraDTO transDTO){
        try{
            Transportadora trans = new Transportadora(transDTO);
            string senhaGerada = trans.GeraSenha();
            return new{
                Resposta = "Senha gerada com sucesso",
                senhaGerada = senhaGerada
            };
        }
        catch(Exception e){
            return new{
                Resposta = "Erro ao gerar senha",
                Erro = e.Message
            };
        }
    }
}