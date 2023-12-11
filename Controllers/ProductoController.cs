using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using APIGAMES.Models;
using System.Collections.Generic;
using System;

using Microsoft.AspNetCore.Cors;

namespace APIGAMES.Controllers
{
    //aqui aplicamos las reglas cors
    [EnableCors("ReglasCors")]

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly DBGAMESContext _dbcontext;
        
        public ProductoController(DBGAMESContext _context)
        {
            _dbcontext = _context;
        }
        //creacion  de API PARA OBTENER UNA LISTA TIPO GET
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = _dbcontext.Productos.Include(c => c.Oplataforma).ToList();
                

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ejecutado", Response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = lista });
            }
        }

        [HttpGet("Obtener")]
        public IActionResult Obtener( int idProducto)
        {
            Producto oproducto = _dbcontext.Productos.Find(idProducto);

            if (oproducto == null)
            {
                return BadRequest("ID no encontrado");
                
            }

            try
            {
            oproducto = _dbcontext.Productos.Include(c => c.Oplataforma).Where(c => c.IdProducto == idProducto).FirstOrDefault();
              
             
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ejecutado", Response = oproducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = oproducto });
            }
        }
        [HttpPost("Guardar")]

        public IActionResult Guardar ([FromBody] Producto objeto)
        {
            try
            {
                _dbcontext.Productos.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }
        [HttpPut("Editar")]

        public IActionResult Editar([FromBody] Producto objeto)
        {

            Producto oproducto = _dbcontext.Productos.Find(objeto.IdProducto);

            if (oproducto == null)
            {
                return BadRequest("ID no encontrado");

            }
            try
            {
                oproducto.IdProducto = objeto.IdProducto is null ? oproducto.IdProducto : objeto.IdProducto;
                oproducto.Nombre = objeto.Nombre is null ? oproducto.Nombre : objeto.Nombre;
                oproducto.Genero = objeto.Genero is null ? oproducto.Genero : objeto.Genero;
                oproducto.Trailer = objeto.Trailer is null ? oproducto.Trailer : objeto.Trailer;
                oproducto.IdPlataforma = objeto.IdPlataforma is null ? oproducto.IdPlataforma : objeto.IdPlataforma;

                _dbcontext.Productos.Update(oproducto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Editado" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }
        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(int IdProducto)
        {
            Producto oproducto = _dbcontext.Productos.Find(IdProducto);

            if (oproducto == null)
            {
                return BadRequest("ID no encontrado");

            }
            try
            {
             
                _dbcontext.Productos.Remove(oproducto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

    }
}
