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
public class exemploController : ControllerBase
{
    public IConfiguration _configuration; //add

    public exemploController(IConfiguration config)
    { //add
        _configuration = config;
    }

    //* ------------------------------------------------ Buscar por id
    [HttpPost]
    [Route("find/{id}")]
    public Entrega FindById(int id)
    {  
        var entrega = Model.Entrega.FindById(id);
        return entrega;
    }

    
}
