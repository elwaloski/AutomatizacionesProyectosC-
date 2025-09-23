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
using Microsoft.Extensions.Logging;

namespace ApiWalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaFolioController : ControllerBase
    {
        private readonly ILogger<ConsultaFolioDatos> _logger;

        public ConsultaFolioController(ILogger<ConsultaFolioDatos> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("CAFsDisponibles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var lista = ConsultaFolioDatos.Listar();
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
                _logger.LogInformation("Se Listaron todos los CAF");
                return Ok(lista); // Devuelve el código de estado 200 OK y la lista si la lista no está vacía
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult DteRangFoli1(string codi_emex, int codi_empr, int tipo_docu, string TipoDTEoBEL)
        {

            var Result = ConsultaFolioDatos.Obtener(codi_emex, codi_empr, tipo_docu, TipoDTEoBEL);
            var Respuesta = Result.Folio_Disponible;

            if (Respuesta == 0)
            {
                string MensajeError = "Error de comunicacion con la Base de datos Error 0";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == -1)
            {
                string MensajeError = "No hay Folios Disponibles Error -1";
                var errorResponse = new
                {
                    Error = MensajeError

                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta== -2)
            {
                string MensajeError = "No hay CAF Disponibles Error -2";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == -5)
            {
                string MensajeError = "Campo codi_emex esta vacio Error -5";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Respuesta == -6)
            {
                string MensajeError = "Codi_emex no Existe o hay un problema al consultar a la Base de datos Error -6";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse);
            }

            if (Respuesta == -7)
            {
                string MensajeError = "Codi Empr no puede ser nulo o 0 Error -7";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse);
            }
            if (Respuesta == -8)
            {
                string MensajeError = "Campo Tipo DTE o tipo BEL esta vacio Error -8";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == -9)
            {
                string MensajeError = "Campo Tipo DTE o tipo BEL no tiene el valor esperado  DTE o BEL Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == -10)
            {
                string MensajeError = "El tipo docu no es compatible con el TipoDTEoBEL Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
           
            var successResponse = new
            {

                Folio_Disponible = Respuesta,
            };
            _logger.LogInformation("ConsultaFolio Correcta Folio_disponible " + Respuesta+" Para el documento tipo "+ tipo_docu);
            return Ok(successResponse);
        }

    }
}
