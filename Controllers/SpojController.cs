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
    public class SpojController : ControllerBase
    {
        public KudContext Context {get; set;}
        public SpojController(KudContext context) => Context = context;


        [Route("Uplati")]
        [HttpPut]
        public async Task<ActionResult> Uplati(int clanarina, int clan)
        {
            if(clanarina < 0 || clan < 0)
            {
                return BadRequest("Losi parametri");
            }
            try
            {
                var spoj = Context.spojs
                            .Where(p=>p.clanarina.ID==clanarina &&p.clan.ClanID==clan).FirstOrDefault();
                spoj.uplata=true;
                await Context.SaveChangesAsync();
                return Ok("Izvrsena uplata");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
        [Route("PovuciUplatu")]
        [HttpPut]
        public async Task<ActionResult>PovuciUplatu(int clanarina, int clan)
        {
            if(clanarina < 0 || clan < 0)
            {
                return BadRequest("Losi parametri");
            }
            try
            {
                var spoj = Context.spojs
                            .Where(p=>p.clanarina.ID==clanarina &&p.clan.ClanID==clan).FirstOrDefault();
                spoj.uplata=false;
                await Context.SaveChangesAsync();
                return Ok("Izvrsen uplata");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
        [Route("NapraviUplatu")]
        [HttpPost]
        public async Task<ActionResult> NapraviUplatu(int idclan, int idclanarina)
        {
            var spoj= new Spoj();
            var clanovi = Context.clans.Where(p=>p.ClanID == idclan).FirstOrDefault();
            var clanarina = Context.clanarinas.Where(p=>p.ID==idclanarina).FirstOrDefault();
            try{
                spoj.clan = clanovi;
                spoj.clanarina=clanarina;
                spoj.uplata = false;
                Context.spojs.Add(spoj);
                await Context.SaveChangesAsync();
                return Ok("Dodata nova uplata");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
        [Route("VratiSveUplate")]
        [HttpGet]
        public async Task<ActionResult> VratiSveUplate(int idclanarine, bool vrstauplate)
        {
            if(vrstauplate !=  true && vrstauplate!=false) return BadRequest("Niste uneli vrstu plate");
            var spojevi = Context.spojs
                            .Include(p=>p.clan)
                            .Where(p=> p.uplata == vrstauplate&&p.clanarina.ID==idclanarine);
            if(spojevi == null)
            {
                return BadRequest("Losee sve");
            }
            return Ok(await spojevi.Select(p=>
                new{
                    Ime = p.clan.Ime_cl,
                    Prezime = p.clan.Prezime_cl,
                    Godine = p.clan.godine_cl,
                    Ansambl = p.clan.ansambl.naziv
                }
            
            ).ToListAsync());
        }

        [Route("VratiSveUplateClana")]
        [HttpGet]
        public async Task<ActionResult> VratiSveUplateClana(bool vrstauplate, int clan)
        {
            if(vrstauplate !=  true && vrstauplate!=false) return BadRequest("Niste uneli vrstu plate");
            var spojevi = Context.spojs
                            .Include(p=>p.clan)
                            .Where(p=> p.uplata == vrstauplate&&p.clan.ClanID==clan);
            if(spojevi == null)
            {
                return BadRequest("Losee sve");
            }
            return Ok(await spojevi.Select(p=>
                new{
                    id=p.clanarina.ID,
                    Naziv=p.clanarina.naziv
                }
            
            ).ToListAsync());
        }

        [Route("PromeniUplate")]
        [HttpPut]
        public async Task<ActionResult> PromeniUplate(int clana,string promene)
        {
            if(string.IsNullOrWhiteSpace(promene)) return BadRequest("Niste uneli promene");
            var promenee =promene.Split('a')
                .Where(x=> int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();
            var spojevi = Context.spojs
                            .Include(p=>p.clanarina)
                            .Include(p=>p.clan)
                            .Where(p=>p.clan.ClanID==clana && promenee.Contains(p.clanarina.ID));
            foreach(var spoj in spojevi)
            {
                if(spoj.uplata== true) spoj.uplata=false;
                else spoj.uplata =true;
            }
            await Context.SaveChangesAsync();
            return Ok("Blaa");
        }

        [Route("DodajNovuClanarinu")]
        [HttpPost]
        public async Task<ActionResult> DodajNovuClanarinu(string nova, string nazivkud)
        {
            if(string.IsNullOrWhiteSpace(nova)) return BadRequest("Niste uneli naziv nove clanaraine");
            if(string.IsNullOrWhiteSpace(nazivkud)) return BadRequest("Niste uneli naziv nove clanaraine");
            var clanovi = Context.clans
                            .Include(p=>p.ansambl)
                            .ThenInclude(p=>p.kud).Where(p=>p.ansambl.kud.naziv_kud == nazivkud);
            try{
                var clanarinaa = new Clanarina();
                clanarinaa.naziv = nova;
                Context.clanarinas.Add(clanarinaa);
                foreach(var clann in clanovi)
                {
                   var spoj= new Spoj();
                   spoj.clan = clann;
                   spoj.clanarina = clanarinaa;
                   Context.spojs.Add(spoj);
                }
                await Context.SaveChangesAsync();
                return Ok("Dodata nova clanarina");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [Route("IzbrisiClanarinu")]
        [HttpDelete]
        public async Task<ActionResult> Izbrisi(string del)
        {
            
            var clanarinaa = Context.clanarinas.Where(p=>p.naziv==del).FirstOrDefault();
            var spojevi = Context.spojs.Where(p=>p.clanarina  == clanarinaa);
            try{
                foreach(var spoj in spojevi)
                {
                   Context.spojs.Remove(spoj);
                }
                Context.clanarinas.Remove(clanarinaa);
                await Context.SaveChangesAsync();
                return Ok("Dodata nova clanarina");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
    }
}