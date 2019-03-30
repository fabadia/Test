using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoEstoquesController : ControllerBase
    {
        private readonly Context _context;

        public PedidoEstoquesController(Context context)
        {
            _context = context;
        }

        // GET: api/PedidoEstoques
        [HttpGet]
        public IEnumerable<object> GetPedidoEstoques()
        {
            return _context.PedidoEstoques
                .Select(x => new
                {
                    x.Id,
                    x.Data,
                    x.Tipo,
                    Filial = x.Filial.Nome,
                    QtdItems = x.ItemPedidoEstoques.Count()
                });
        }

        // GET: api/PedidoEstoques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoEstoque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoEstoque = await _context.PedidoEstoques
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Data,
                    x.Tipo,
                    x.FilialId,
                    FilialNome = x.Filial.Nome,
                    ItemPedidoEstoques = x.ItemPedidoEstoques
                        .Select(i => new
                        {
                            i.Id,
                            i.ProdutoId,
                            ProdutoDescricao = i.Produto.Descricao,
                            i.Quantidade
                        })
                })
                .ToListAsync();

            if (pedidoEstoque == null)
            {
                return NotFound();
            }

            return Ok(pedidoEstoque);
        }

        // PUT: api/PedidoEstoques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoEstoque([FromRoute] int id, [FromBody] PedidoEstoque pedidoEstoque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoEstoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoEstoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoEstoqueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PedidoEstoques
        [HttpPost]
        public async Task<IActionResult> PostPedidoEstoque([FromBody] PedidoEstoque pedidoEstoque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pedidoEstoque.ItemPedidoEstoques.GroupBy(x => x.ProdutoId).Any(x => x.Count() > 1))
            {
                ModelState.AddModelError(nameof(pedidoEstoque.ItemPedidoEstoques), "Produtos duplicados");
                return BadRequest(ModelState);
            }

            foreach(var itemPedidoEstoque in pedidoEstoque.ItemPedidoEstoques)
            {
                var estoque = _context.Estoques
                    .Where(x => x.FilialId == pedidoEstoque.FilialId && x.ProdutoId == itemPedidoEstoque.ProdutoId)
                    .FirstOrDefault();
                if (estoque == null)
                {
                    estoque = new Estoque
                    {
                        FilialId = pedidoEstoque.FilialId,
                        ProdutoId = itemPedidoEstoque.ProdutoId,
                        Quantidade = 0
                    };
                    _context.Estoques.Add(estoque);
                }

                if (pedidoEstoque.Tipo == TipoPedido.Entrada)
                    estoque.Quantidade += itemPedidoEstoque.Quantidade;
                else
                    estoque.Quantidade -= itemPedidoEstoque.Quantidade;

                if (estoque.Quantidade < 0)
                {
                    ModelState.AddModelError(nameof(pedidoEstoque.ItemPedidoEstoques), "Estoque negativo");
                    return BadRequest(ModelState);
                }
            }
            _context.PedidoEstoques.Add(pedidoEstoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoEstoque", new { id = pedidoEstoque.Id }, pedidoEstoque);
        }

        // DELETE: api/PedidoEstoques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoEstoque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoEstoque = await _context.PedidoEstoques.FindAsync(id);
            if (pedidoEstoque == null)
            {
                return NotFound();
            }

            _context.PedidoEstoques.Remove(pedidoEstoque);
            await _context.SaveChangesAsync();

            return Ok(pedidoEstoque);
        }

        private bool PedidoEstoqueExists(int id)
        {
            return _context.PedidoEstoques.Any(e => e.Id == id);
        }
    }
}