using IDGS902_API.Context;
using IDGS902_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS902_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly AppDBContext _context;
        public GruposController (AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.alumnos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "Alumnos")]
        public ActionResult Get(int id)
        {
            try
            {
                var alum = _context.alumnos.FirstOrDefault(x => x.id == id);
                return Ok(alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] alumnos alum) {
            try
            {
                _context.alumnos.Add(alum);
                _context.SaveChanges();
                return CreatedAtRoute("Alumnos", new { id = alum.id }, alum);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] alumnos alum)
        {
            try
            {
                if(alum.id == id)
                {
                    _context.Entry(alum).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Alumnos", new { id = alum.id }, alum);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]

        public ActionResult Delete(int id)
        {
            try
            {
                var alum = _context.alumnos.FirstOrDefault(alumnos => alumnos.id == id);
                if(alum != null)
                {
                    _context.alumnos.Remove(alum);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
