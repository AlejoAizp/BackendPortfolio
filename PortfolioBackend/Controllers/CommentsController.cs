using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AplicationDbContextComments _context;

        public CommentsController(AplicationDbContextComments context)
        {
            _context =  context;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComents = await _context.Comments.ToListAsync();
                return Ok(listComents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CommentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Comments Comments)
        {

            try
            {
                _context.Add(Comments);
                await _context.SaveChangesAsync();
                return Ok(Comments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comments Comments)
        {
            try
            {
                if (id !=Comments.Id)
                {
                    return NotFound();
                }

                _context.Update(Comments);
                await _context.SaveChangesAsync();
                return Ok(new { message = "This Comment was updated successfully!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Comments = await _context.Comments.FindAsync(id);
                if (Comments == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Comments.Remove(Comments);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "This message was deleted successfully!" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

