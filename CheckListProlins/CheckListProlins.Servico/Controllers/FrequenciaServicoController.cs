using AutoMapper;
using SIPE.Servico.Interface;
using System;
using System.Collections.Generic;
using SIPE.Servico.DTO;
using SIPE.Repositorio.Interface;
using SIPE.Repositorio.Model;
using System.Linq;

namespace SIPE.Servico.Controllers
{
    public class FrequenciaServicoController : IFrequenciaServico
    {
        private readonly IMapper _mapper;
        private readonly IFrequenciaData _frequencia;

        public FrequenciaServicoController(IMapper mapper, IFrequenciaData frequencia)
        {
            _mapper = mapper;
            _frequencia = frequencia;
        }
        public List<FrequenciaDTO> Get()
        {
            var listaFrequencia = _frequencia.Listar();
            var listaFrequenciaDTO = _mapper.Map<List<Frequencia>, List<FrequenciaDTO>>(listaFrequencia);

            return listaFrequenciaDTO;
        }

        public FrequenciaDTO Get(int Id)
        {
            var frequencia = _frequencia.Buscar(Id);
            var listaFrequenciaDTO = _mapper.Map<Frequencia, FrequenciaDTO>(frequencia);

            return listaFrequenciaDTO;
        }

        public void Post(FrequenciaDTO frequencia, List<int> presencas)
        {
            var frequenciaData = _mapper.Map<Frequencia>(frequencia);

            _frequencia.Salvar(frequenciaData, presencas);
        }

        public void Put(FrequenciaDTO frequencia)
        {
            throw new NotImplementedException();
        }
    }
}