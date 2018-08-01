using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Domain.Services;
using Cedro.Domain.Interfaces.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Services
{
    public class PratoService : CedroService<Prato,IPratoRepository,int>, IPratoService
    {
        public PratoService(IPratoRepository _repository) : base(_repository)
        {
        }
    }
}
