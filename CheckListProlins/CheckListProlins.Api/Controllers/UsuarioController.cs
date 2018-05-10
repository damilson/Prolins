using CheckListProlins.Core;
using Entidades;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CheckListProlins.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioCore _usuario;

        public UsuarioController(IUsuarioCore usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Retorna uma lista de usuários
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        public List<Usuario> Get()
        {
            return _usuario.Listar();
        }


        /// <summary>
        /// Retorna os dados de um usuário
        /// </summary>
        /// <param name="id">Id do usuario a ser retornado</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var usuario = _usuario.Buscar(id);

                if (usuario != null)
                    return Ok(usuario);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Insere novo usuário
        /// </summary>
        /// <param name="model">Novo usuário a ser cadastrado</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        // POST: api/UsuarioApi
        public IHttpActionResult Post([FromBody]Usuario model)
        {
            try
            {
                var usuarioSalvo = _usuario.Salvar(model);
                return Ok(usuarioSalvo);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Altera os dados de um usuário
        /// </summary>
        /// <param name="model">Usuário a ser alterado</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        // PUT: api/UsuarioApi/5
        public IHttpActionResult Put([FromBody]Usuario model)
        {
            try
            {
                _usuario.Editar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/UsuarioApi/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _usuario.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }
    }
}
