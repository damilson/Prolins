using AutoMapper;
using SIPE.Repositorio.Interface;
using SIPE.Repositorio.Model;
using SIPE.Servico.DTO;
using SIPE.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util.Alerta;

namespace SIPE.Servico.Controllers
{
    public class AgendaServicoController : IAgendaServico
    {
        private readonly IAgendaData _agenda;
        private readonly IMapper _mapper;

        public AgendaServicoController(IAgendaData agenda, IMapper mapper)
        {
            _agenda = agenda;
            _mapper = mapper;
        }
        
        // GET: api/AgendaServico
        public List<AgendaDTO> Get()
        {
            var listAgemda = _agenda.AgendaLista();

            var listAgendaDTO = _mapper.Map<List<Agenda>, List<AgendaDTO>>(listAgemda);

            return listAgendaDTO;
        }

        // GET: api/AgendaServico/5
        public AgendaDTO Get(int id)
        {
            var agenda = _agenda.Buscar(id);

            var agendaDTO = _mapper.Map<Agenda, AgendaDTO>(agenda);

            return agendaDTO;
        }

        // POST: api/AgendaServico
        public void Post(AgendaDTO agendaDTO)
        {
            validar(agendaDTO);

            var agenda = _mapper.Map<AgendaDTO, Agenda>(agendaDTO);

            _agenda.Salvar(agenda);
        }

        // PUT: api/AgendaServico/5
        public void Put(AgendaDTO agendaDTO)
        {
            validar(agendaDTO);

            var agenda = _mapper.Map<AgendaDTO, Agenda>(agendaDTO);

            _agenda.Editar(agenda);
        }

        // DELETE: api/AgendaServico/5
        public void Delete(int id)
        {
            _agenda.Deletar(id);
        }

        private void validar(AgendaDTO agendaDTO)
        {
            if(string.IsNullOrWhiteSpace(agendaDTO.Conteudo))
                throw new Exception("O conteudo da agenda não pode ser nulo!");

            if (agendaDTO.Data == null)
                throw new Exception("A data da agenda deve ser infomada!");

            if (agendaDTO.Disciplina.DisciplinaId == 0)
                throw new Exception("A didciplima da agenda deve ser informada!");

            if (agendaDTO.Turma.TurmaId == 0)
                throw new Exception("A turma da agenda deve ser informada");
        }
    }
}
