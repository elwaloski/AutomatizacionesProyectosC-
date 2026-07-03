using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Custom;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Text;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly DbpruebaContext _dbPruebaContext;
        private readonly Utilidades _utilidades;
        public AccesoController(DbpruebaContext dbPruebaContext, Utilidades utilidades)
        {
            _dbPruebaContext = dbPruebaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {
            try
            {
                // 🔹 Verificar si el correo ya existe
                var correoExiste = await _dbPruebaContext.Usuarios
                    .AnyAsync(u => u.Correo == objeto.Correo);

                if (correoExiste)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        isSuccess = false,
                        message = "El correo ya se encuentra registrado."
                    });
                }

                // 🔹 Crear modelo de usuario
                var modeloUsuario = new Usuario
                {
                    Nombre = objeto.Nombre,
                    Correo = objeto.Correo,
                    Clave = objeto.Clave
                };

                // 🔹 Insertar en la base de datos
                await _dbPruebaContext.Usuarios.AddAsync(modeloUsuario);
                await _dbPruebaContext.SaveChangesAsync();

                if (modeloUsuario.IdUsuario != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        isSuccess = true,
                        message = "Usuario registrado con éxito."
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        isSuccess = false,
                        message = "No se pudo registrar el usuario."
                    });
                }
            }
            catch (Exception ex)
            {
                // 🔹 Manejo de error
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
        }




        [HttpPost]
        [Route("TokenJWT")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var clave = "VHVDbGF2ZVN1cGVyU2VjcmV0YURlQWxtZW5vczMyQ2FyYWN0ZXJlcyE=";
            var bytes = Convert.FromBase64String(clave);
            Console.WriteLine(bytes.Length); // Debe ser >= 32

            try
            {
                // 🔹 Validar si la clave viene en Base64
                string claveDecodificada;
                if (EsBase64(objeto.Clave))
                {
                    claveDecodificada = Encoding.UTF8.GetString(Convert.FromBase64String(objeto.Clave));
                }
                else
                {
                    claveDecodificada = objeto.Clave; // Se usa como viene
                }

                // 🔹 Buscar usuario en la base de datos
                var usuarioEncontrado = await _dbPruebaContext.Usuarios
                    .Where(u =>
                        u.Correo == objeto.Correo &&
                        u.Clave == claveDecodificada
                    )
                    .FirstOrDefaultAsync();

                if (usuarioEncontrado == null)
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        isSuccess = false,
                        token = "",
                        message = "Usuario o clave inválidos" // 👈 mensaje claro
                    });
                else
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        isSuccess = true,
                        token = _utilidades.generarJWT(usuarioEncontrado),
                        message = "Token exitoso"
                    });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// Verifica si una cadena es Base64 válida.
        /// </summary>
        private bool EsBase64(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // El largo debe ser múltiplo de 4
            if (input.Length % 4 != 0)
                return false;

            Span<byte> buffer = new Span<byte>(new byte[input.Length]);
            return Convert.TryFromBase64String(input, buffer, out _);
        }


    }
}
