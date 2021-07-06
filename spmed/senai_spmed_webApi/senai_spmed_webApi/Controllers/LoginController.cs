using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using senai_spmed_webApi.Repositories;
using senai_spmed_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// objeto _usuarioRepository herda os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// _usuarioRepository recebe os métodos de seu repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        
        /// <summary>
        /// faz a autenticação do usuario
        /// </summary>
        /// <param name="login">email e senha que deverão ser passados</param>
        /// <returns>um usuário logado</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);
 
                if (usuarioBuscado == null)
                {

                    return NotFound("E-mail ou senha inválidos!");
                }

                //payload
                var claims = new[]
                {
                    
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())

                };

                //chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmed-chave-autenticacao"));

                //header
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //gera o token
                var token = new JwtSecurityToken(
                    issuer: "spmed.webApi",                 // emissor do token
                    audience: "spmed.webApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                //retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
