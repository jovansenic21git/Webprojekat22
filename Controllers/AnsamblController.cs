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
    public class AnsamblController : ControllerBase
    {
        public KudContext Context {get; set;}
        public AnsamblController(KudContext context) => Context = context;

        
        [Route("DodajAnsambl")]
        [EnableCors("CORS")]
        [HttpGet]
        public async Task<ActionResult> DodajAnsambl(string kud,int id_ruk,string nz, int pr)
        {
            if(string.IsNullOrWhiteSpace(nz) || nz.Length>50)
            {
                return BadRequest("Lose unet naziv ansambla!");
            }
            if(pr<0)
            {
                return BadRequest("Lose unet broj proba!");
            }
            
            if(string.IsNullOrWhiteSpace(kud) || kud.Length>100)
            {
                return BadRequest("Lose unet naziv ansambla!");
            }
            if(id_ruk<0)
            {
                return BadRequest("Lose unet broj proba!");
            }
            var rukovdilac = Context.rukovodilacs.Where(p=>p.ID_rk==id_ruk).FirstOrDefault();
            var kudd = Context.kuds.Where(p=>p.naziv_kud == kud).FirstOrDefault();
            try{
                var ansambl = new Ansambl();
                ansambl.naziv=nz;
                ansambl.probe=pr;
                ansambl.kud=kudd;
                ansambl.rukovodilac=rukovdilac;
                Context.ansambls.Add(ansambl);
                await Context.SaveChangesAsync();
                return Ok($"Ispravno dodat anasambl! ID : {ansambl.ID_an}");
            }
            catch(Exception e)
            {return BadRequest(e.Message);}
        }
        [Route("PreuzmiAnsambl/{nazivkuda}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiAnsambl(string nazivkuda)
        {
            var anasambli = await Context.ansambls
            .Where(p=>p.kud.naziv_kud == nazivkuda) 
            .Select(p=>
                        new{
                            Id= p.ID_an,
                            Naziv = p.naziv,
                            Probemes =p.probe,
                            Rukovodilac=p.rukovodilac,
                            Count = p.clanovi.Count
                        }).ToListAsync();
            return Ok(anasambli);
        }
        [Route("Preuzmiprosekposeta")]
        [HttpGet]
        public ActionResult Preuzmiprosekposeta(int anasambl)
        {
            var clanovi = Context.clans.Include(p=>p.ansambl)
                                        .Where(p=>p.ansambl.ID_an==anasambl);
            var anasambll = Context.ansambls.Where(p=>p.ID_an == anasambl).FirstOrDefault();
            int sum=0;
            int kol =0;
            foreach(var clann in clanovi)
            {
                sum += clann.dolasci;
                kol++;
            }
            int prosek = sum / kol;

            return Ok(new {
                prob = prosek
            });
        }
        
    }
}