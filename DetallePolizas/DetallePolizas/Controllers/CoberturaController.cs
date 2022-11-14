using Microsoft.AspNetCore.Mvc;
using DetallePolizas.Models.DB;

namespace DetallePolizas.Controllers
{
    [ApiController]
    [Route("cobertura")]
    public class CoberturaController : ControllerBase
    {
        private readonly BrokerSegurosContext _context;

        public CoberturaController(BrokerSegurosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listCoberturas")]
        public dynamic listCoberturas()
        {
            try
            {
                List<Cobertura> coberturas = new List<Cobertura>();
                coberturas = _context.Coberturas.ToList<Cobertura>();
                return coberturas;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("getCobertura")]
        public dynamic getCobertura(int id)
        {
            try
            {
                Cobertura cobertura = new Cobertura();
                cobertura = _context.Coberturas.Find(id);
                return cobertura;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("saveCobertura")]
        public dynamic saveCobertura(Cobertura cobertura)
        {
            try
            {
                _context.Coberturas.Add(cobertura);
                _context.SaveChanges();
                return cobertura;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("deleteCobertura")]
        public dynamic deleteCobertura(int id)
        {
            try
            {
                Cobertura cobertura = _context.Coberturas.Find(id);
                _context.Coberturas.Remove(cobertura);
                _context.SaveChanges();
                return new
                {
                    success = true,
                    message = "Cobertura Eliminada",
                    result = ""
                };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("modificarCobertura")]
        public dynamic modificarCobertura(Cobertura cobertura)
        {
            try
            {
                var cob = _context.Coberturas.Attach(cobertura);
                cob.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return cobertura;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
