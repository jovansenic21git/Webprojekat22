using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Awe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RukovodilacController : ControllerBase
    {
        public KudContext Context {get; set;}
        public RukovodilacController(KudContext context) => Context = context;

        [Route("DodajAnsambl")]
        [EnableCors("CORS")]
        [HttpPost]
        public async Task<ActionResult> DodajRukovodioca(string im,  string pr, int god )
        {
            if(string.IsNullOrWhiteSpace(im) || im.Length>30)
            {
                return BadRequest("Lose uneto ime rukovodioca!");
            }
            if(string.IsNullOrWhiteSpace(pr) || pr.Length>30)
            {
                return BadRequest("Lose uneto ime rukovodioca!");
            }
            if(god< 21)
            {
                return BadRequest("Lose unete godine!");
            }

            try{
                var rukovodilac = new Rukovodilac
                {
                    ime_rk =im,
                    prezime_rk=pr,
                    godine_rk = god
                };
                Context.rukovodilacs.Add(rukovodilac);
                await Context.SaveChangesAsync();
                return Ok($"Ispravno dodat rukovodilac! ID : {rukovodilac.ID_rk}");
            }
            catch(Exception e)
            {return BadRequest(e.Message);}
        }
        [Route("PreuzmiRukovodilac")]
        [HttpGet]
        public ActionResult PreuzmiRukovodilac(string kud, int ansambl)
        {
            var rukovdilac = Context.ansambls
                            .Include(p=> p.rukovodilac)
                            .Where(p=> p.kud.naziv_kud == kud&&p.ID_an==ansambl).FirstOrDefault();
            return Ok(
                new{
                    ID =rukovdilac.rukovodilac.ID_rk,
                    Ime = rukovdilac.rukovodilac.ime_rk,
                    Prezime = rukovdilac.rukovodilac.prezime_rk,
                    Godine = rukovdilac.rukovodilac.godine_rk
                }
            );
            
        }
        
    }
}