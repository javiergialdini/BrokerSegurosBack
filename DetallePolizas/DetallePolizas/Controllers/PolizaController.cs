using DetallePolizas.Models.DB;
using Microsoft.AspNetCore.Mvc;
using DetallePolizas.Controllers;
using Newtonsoft.Json;

namespace DetallePolizas.Controllers
{
    [ApiController]
    [Route("poliza")]
    public class PolizaController : ControllerBase
    {

        private readonly BrokerSegurosContext _context;

        public PolizaController(BrokerSegurosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listPolizas")]
        public dynamic listPolizas()
        {
            try
            {
                List<Poliza> polizas = new List<Poliza>();
                List<CoberturasPoliza> coberturasPoliza = new List<CoberturasPoliza>();

                polizas = _context.Polizas.ToList<Poliza>();
                
                foreach (Poliza poliza in polizas)
                {   
                    coberturasPoliza = _context.CoberturasPolizas.Where(x => x.IdPoliza == poliza.IdPoliza).ToList<CoberturasPoliza>();
                }
                return polizas;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("listCoberturasPoliza")]
        public dynamic listCoberturasPoliza(int id)
        {
            try
            {
                List<Cobertura> coberturas = new List<Cobertura>();
                List<CoberturasPoliza> coberturasPoliza = new List<CoberturasPoliza>();
                coberturasPoliza = _context.CoberturasPolizas.Where(x => x.IdPoliza == id).ToList<CoberturasPoliza>();

                foreach (CoberturasPoliza cobPoliza in coberturasPoliza)
                {
                    coberturas.Add(_context.Coberturas.Find(cobPoliza.IdCobertura));
                }
                return coberturas;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet]
        [Route("getPoliza")]
        public dynamic getPoliza(int id)
        {
            try
            {
                Poliza poliza = new Poliza();
                List<CoberturasPoliza> coberturasPoliza = new List<CoberturasPoliza>();

                poliza = _context.Polizas.Find(id);
                coberturasPoliza = _context.CoberturasPolizas.Where(x => x.IdPoliza == poliza.IdPoliza).ToList<CoberturasPoliza>();
                return poliza;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpPost]
        [Route("savePoliza")]
        public dynamic savePoliza(Poliza poliza)
        {
            try
            {
                _context.Polizas.Add(poliza);
                _context.SaveChanges();
                return poliza;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("saveCoberturaPoliza")]
        public dynamic saveCoberturaPoliza(CoberturasPoliza coberturaPoliza)
         {
            try
            {
                _context.CoberturasPolizas.Add(coberturaPoliza);
                _context.SaveChanges();
                return coberturaPoliza;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("deletePoliza")]
        public dynamic deletePoliza(int id)
        {
            try
            {
                Poliza poliza = _context.Polizas.Find(id);
                List<CoberturasPoliza> coberturasPoliza = _context.CoberturasPolizas.Where(x => x.IdPoliza == poliza.IdPoliza).ToList<CoberturasPoliza>();
                
                foreach (CoberturasPoliza cp in coberturasPoliza)
                {
                    _context.CoberturasPolizas.Remove(cp);
                    _context.SaveChanges(); 
                }
                _context.Polizas.Remove(poliza);
                _context.SaveChanges();
                return new
                {
                    success = true,
                    message = "Poliza Eliminada",
                    result = ""
                };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("deleteCoberturaPoliza")]
        public dynamic deleteCoberturaPoliza(int id)
        {
            try
            {
                CoberturasPoliza cobPoliza = _context.CoberturasPolizas.Find(id);
                _context.CoberturasPolizas.Remove(cobPoliza);
                _context.SaveChanges();
                return new
                {
                    success = true,
                    message = "Cobertura de poliza eliminada",
                    result = ""
                };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("modificarPoliza")]
        public dynamic modificarCobertura(Poliza poliza)
        {
            try
            {
                var pol = _context.Polizas.Attach(poliza);
                pol.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return poliza;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
