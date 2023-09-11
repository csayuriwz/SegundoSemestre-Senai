using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos!");
                }

                //Caso encontre o usuario buscado, prossegue para a criacao do token
                //1- definir as informacoes(Claims) que serao fornecidos pelo token (PayLoad)

                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuario.ToString()),  
                    
                   
                };

                //2 definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev"));

                //return Ok(usuarioBuscado);

                //3- definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4- gerar o token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "senai.inlock.webApi.",

                    //destinatario
                    audience: "senai.inlock.webApi.",

                    //dados definidos nas claims (PayLoad)
                    claims: claims,

                    //tempo de expiracao
                    expires: DateTime.Now.AddMinutes(10),

                    //credenciais do token
                    signingCredentials: creds

                );

                //5-retornar o token

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });

            }
            catch (Exception erro)
            {

                throw;
            }
        }
    }

}

