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
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiWalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParaEmprController : ControllerBase
    {
        private readonly ILogger<ConsultaFolioDatos> _logger;

        public ParaEmprController(ILogger<ConsultaFolioDatos> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("ParametrosEmpresas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var lista = ParaEmprDatos.Listar();
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
        public ActionResult ParaEmpr (string codi_emex, string codi_paem, int codi_empr)
        {
            var Result = ParaEmprDatos.Obtener(codi_emex, codi_paem, codi_empr);
            var Respuesta = Result.desc_paem;

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
                string MensajeError = "Falta Parametros codi_paem Error -6";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);

                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == "-7")
            {
                string MensajeError = "Falta Parametros codi_emex Error -7";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);

                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == "-8")
            {
                string MensajeError = "No existe Parametro en el holding o empresa que se ha ingresado Error -8";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);

                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == "-9")
            {
                string MensajeError = "Error al consultar a la Base de datos Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);

                return NotFound(errorResponse); //no existe 404
            }

            if (Respuesta == "-10")
            {
                string MensajeError = "codi_empr Ingresado no puede ser 0 Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);

                return NotFound(errorResponse); //no existe 404
            }

            _logger.LogInformation("Se lista el parametro");
            return Ok(Result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult Put([FromBody] ParaEmprEXP oParaEmpr)
        {
            string? CodigoSalida = ParaEmprDatos.Modificar(oParaEmpr);

            if (CodigoSalida == "0")
            {
                string MensajeError = "No se logra Actualizar Contactar con Administrador Error -0";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            if (CodigoSalida == "-5")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo codi_emex Error -5";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-6")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo codi_paem Error -6";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-7")
            {
                string MensajeError = "No se logro actualizar!! Falta o se debe correguir campo codi_empr Error -7";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-8")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo valo_paem Error -8";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-9")
            {
                string MensajeError = "Codi_emex ,codi_empr o codi_paem ingresado no existe en la Base de datos Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-10")
            {
                string MensajeError = "Error comunicacion con la Base de datos Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            var successResponse = new
            {

                Actualizado = CodigoSalida,
            };
            _logger.LogInformation(CodigoSalida);
            return Ok(successResponse);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult  Post([FromBody] ParaEmpr oParaEmpr)
        {
            string Result =ParaEmprDatos.Registrar(oParaEmpr);

            if (Result == "0")
            {
                string MensajeError = "No se logra Actualizar verificar largos y formato correco de los campos !!! Contactar con Administrador Error -0";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            if (Result == "-5")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo codi_emex Error -5";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-6")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo codi_empr Error -6";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-7")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo codi_paem Error -7";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-8")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo tipo_como Error -8";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-9")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo desc_paem Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if(Result == "-10")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo valo_paem Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-11")
            {
                string MensajeError = "No se logro actualizar Falta o se debe correguir campo obli_paem Error -11";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-12")
            {
                string MensajeError = "Parametro que intenta ingresar ya Existe Error -12";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-13")
            {
                string MensajeError = "Error Consultando en la base de datos Error -13";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (Result == "-14")
            {
                string MensajeError = "Error Codi_emex Consultando no existe en la base de datos Error -14";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
           
            var successResponse = new
            {

                Insertado = Result,
            };
            _logger.LogInformation(Result);
            return Ok(successResponse);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Delete(ParaEmprEli oParaEmpr)
        {
            string Codigo= ParaEmprDatos.Eliminar(oParaEmpr);

            JObject jsonObject = JObject.Parse(Codigo);

            string CodigoSalida = (string)jsonObject["Codigos"];

            if (CodigoSalida == "-9")
            {
                string MensajeError = "Campo codi_emex esta vacio o no existe Error -9";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-10") 
            {
                string MensajeError = "Codi_emex ingresado no existe Error -10";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }

            if (CodigoSalida == "-11")
            {                 
                string MensajeError = "campo codi_paem no esta definido o esta mal ingresado  Error-11";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-12")
            {
                string MensajeError = "Se debe correguir campo codi_empr Error -12";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            if (CodigoSalida == "-13")
            {
                string MensajeError = "Parametro que se queire eliminar no existe Error -13";
                var errorResponse = new
                {
                    Error = MensajeError
                };
                _logger.LogError(MensajeError);
                return NotFound(errorResponse); //no existe 404
            }
            var successResponse = new
            {

                Eliminado = CodigoSalida,
            };
            _logger.LogInformation(CodigoSalida);
            return Ok(successResponse);

        }
    }
}
