using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using senai_inlock_webApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_inlock_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto para herdar os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// _usuarioRepository recebe os métodos de seu repositorio
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz a autenticação de um usuario
        /// </summary>
        /// <param name="login">retorna um usuario caso for encontrado, e um status code</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult BuscarEmailSenha(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("O usuário não foi encontrado");
            }

            //caso enconte um usuário, faz a criação do token

            // Define os dados que serão fornecidos no token (payload)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

            };

            //vai definir a chave de acesso (signature)
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-autenticacao-ultra-secreta"));

            //define as credenciais do token (header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //criar o token
            var token = new JwtSecurityToken(
                issuer: "inlock.webApi",                //emissor do token
                audience: "inlock.webApi",              //destinatário do token
                claims: claims,                         //dados que foram criados na variavel claims
                expires: DateTime.Now.AddMinutes(30),   //tempo de expiração do token
                signingCredentials: creds               //credenciais do token

           );

            //retorna um ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });


        }



    }
}
