using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWalde.Data;
using ApiWalde.Models;
using ApiWalde.Datos;

namespace ApiWalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaBELController : ControllerBase
    {
        private readonly ILogger<ConsultaDTEDatos> _logger;


        public ConsultaBELController(ILogger<ConsultaDTEDatos> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ConsultaBELs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var lista = ConsultaBELDatos.Listar();
            if (lista == null || lista.Count == 0)
            {
                var errorResponse = new
                {
                    Error = "Error de comunicacion con la Base de datos"
                };
                _logger.LogError("Error de comunicacion con la Base de datos");
                return NotFound(errorResponse); //no existe 404
            }
            else
            {
                _logger.LogInformation("Se Listaron todas las BELs");
                return Ok(lista); // Devuelve el código de estado 200 OK y la lista si la lista no está vacía
            }

           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult ConsultaBEL (string codi_emex, int codi_empr, int tipo_docu, int foli_docu)
        {
            var Result = ConsultaBELDatos.Obtener(codi_emex, codi_empr, tipo_docu, foli_docu);
            var Respuesta = Result.Codi_emex;

            if (Respuesta == "0")
            {
                string MensajeError = "Error de comunicacion con la Base de datos Error 0";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-5")
            {
                string MensajeError = "Faltan ambos Parametros codi_emex & codi_paem Error -5";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-6")
            {
                string MensajeError = "Error en campo Codi_empr es nulo,Menor a 0 o su valor es 0!! Error -6";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-7")
            {
                string MensajeError = "Error en campo Tipo Docu  es nulo,Menor a 0 o su valor es 0!! Error -7";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-8")
            {
                string MensajeError = "Error en campo Foli_docu es nulo,Menor a 0 o su valor es 0!! Error -8";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-9")
            {
                string MensajeError = "Error Codi_emex no existe o Error en consultar a la Base de datos!! Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-10")
            {
                string MensajeError = "Error Codi_empr no existe en el holding  Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-11")
            {
                string MensajeError = "Error Tipo Docu ingresado no es compatible con las Boletas electronicas Error -11";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == "-12")
            {
                string MensajeError = "Error Folio no existe Error -12";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            _logger.LogInformation("Consulta BEL exitosa");
            return Ok(Result);
        }
        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public void Delete(int id)
        {
        }
        */
    }
}
