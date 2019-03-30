using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private readonly Context _context;

        public EstoquesController(Context context)
        {
            _context = context;
        }

        // GET: api/Estoques
        [HttpGet]
        public IEnumerable<object> GetEstoques()
        {
            return _context.Estoques
                .Select(x => new {
                    x.Id,
                    Filial = x.Filial.Nome,
                    x.Produto.Descricao,
                    x.Quantidade
                });
        }
    }
}