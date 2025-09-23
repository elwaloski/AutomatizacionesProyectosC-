using APIQA.Datos;
using APIQA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIQA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaDTOController : ControllerBase
    {
        private readonly ILogger<ConsultaDTEDatos> _logger;

        public ConsultaDTOController(ILogger<ConsultaDTEDatos> logger)
        {
            _logger = logger;
        }

        // GET: api/<ConsultaDTOController>
        [HttpGet]
        [Route("RecuperaFolio")]
        public IActionResult GetUltimoFolio([FromQuery] string idenRece, [FromQuery] string tipoDocu, [FromQuery] string? codiEmex, [FromQuery] string? modelo)
        {
            try
            {
                _logger.LogInformation("*********** Inicio: GetUltimofolio ***************");
                _logger.LogInformation($"Pametros de entrada idenRece: {idenRece}; tipoDocu: {tipoDocu}; codiEmex: {codiEmex}; modelo: {modelo}");
                decimal folio = ConsultaDTODatos.UltimoFolioRecepcionado(idenRece, tipoDocu, null);
                _logger.LogInformation("FolioRecuperado: " + folio);
                return Ok(new { folioRecuperado = folio + 1});
            }
            catch (Exception e)
            {
                _logger.LogError("Error: " + e.Message);
                return StatusCode(500, new { error = "Se ha producido un error interno" });
            }
            finally
            {
                _logger.LogInformation("*********** Fin: GetUltimofolio ***************");
            }
        }

        [HttpGet]
        [Route("EjecutaCargaDTO")]
        public IActionResult EjecutaCargaDTO()
        {
            try
            {
                _logger.LogInformation("*************Inicia: EjecutaCargaDTO()*************");

                //contar cuantos registros debe cargar
                int cantCola = ConsultaDTODatos.CountQmtaReceInfo();
                decimal corrIni = ConsultaDTODatos.UltimoCorrContDteControl();

                if (cantCola == 0)
                {
                    return UnprocessableEntity(new
                    {
                        resultadoPrueba = "No Ejecutado",
                        mensaje = "No hay datos para procesar en la cola"
                    });
                }

                string pathEjecutable = $"{Environment.GetEnvironmentVariable("homeDir")}\\bin\\prcFileAEI_RCP.bat";
                _logger.LogInformation("Ejecutar: " + pathEjecutable);

                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{pathEjecutable}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };
                string output = "";
                using (Process? process = Process.Start(startInfo))
                {
                    if(process is not null)
                    {
                        output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                    }
                }

                //contar cuantos cargo
                decimal corrFin = ConsultaDTODatos.UltimoCorrContDteControl();

                if ((corrFin - corrIni) != cantCola)
                {
                    return UnprocessableEntity(new
                    {
                        resultadoPrueba = "Fallido",
                        resultadoEsperado = $"Se esperaba cargar {cantCola} documento(s)",
                        resultadoObtenido = $"Se cargan {corrFin - corrIni} documento(s)"
                    });
                }

                _logger.LogInformation("Proceso de carga ejecutado sin errores");
                return Ok(new 
                {
                    resultadoPrueba = "Pasado",
                    resultadoEsperado = $"Se esperaba cargar {cantCola} documento(s)",
                    resultadoObtenido = $"Se cargan {corrFin - corrIni} documento(s)"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, new { error = "Se produce un error al ejecutar el proceso de carga, verificar el log"});
            }
            finally
            {
                _logger.LogInformation("*************Fin: EjecutaCargaDTO()*************");
            }
        }

        //// GET api/<ConsultaDTOController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ConsultaDTOController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ConsultaDTOController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ConsultaDTOController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
