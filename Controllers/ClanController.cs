using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Awe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanController : ControllerBase
    {
        public KudContext Context {get; set;}
        public ClanController(KudContext context) => Context = context;
        [Route("PreuzmiClanove/{ansambl}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanove(int ansambl, string kud)
        {
            if(string.IsNullOrWhiteSpace(kud)) return BadRequest("Niste dodali ime kuda");
            var clanovi = await Context.clans
            .Include(p=>p.ansambl)
            .ThenInclude(p=>p.kud)
            .Where(p=>p.ansambl.ID_an == ansambl && p.ansambl.kud.naziv_kud==kud) 
            .Select(p=>
                        new{
                            Id= p.ClanID,
                            Ime = p.Ime_cl,
                            Prezime =p.Prezime_cl,
                            Godine = p.godine_cl,
                            Dolasci = p.dolasci,
                            DatumUpis = p.datumupisa.ToString("yyyy-MM-dd"),
                            maxdolasci= p.ansambl.probe
                        }).ToListAsync();
            return Ok(clanovi);
        }
        [Route("PreuzmiClanoveKuda")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanoveKuda(string kud)
        {
            if(string.IsNullOrWhiteSpace(kud)) return BadRequest("Niste uneli kud");
            var clanovi = await Context.clans
            .Include(p=>p.ansambl)
            .ThenInclude(p=>p.kud)
            .Where(p=>p.ansambl.kud.naziv_kud == kud) 
            .Select(p=>
                        new{
                            Id= p.ClanID,
                            Ime = p.Ime_cl,
                            Prezime =p.Prezime_cl,
                            Godine = p.godine_cl,
                            Dolasci = p.dolasci,
                            DatumUpis=p.datumupisa,
                            maxdolasci=p.ansambl.probe
                        }).ToListAsync();
            return Ok(clanovi);
        }

        [Route("PromeniDolazak")]
        [HttpPut]
        public async Task<ActionResult> PromeniDolazak(int clan, int dolazak)
        {
            if (dolazak < 0 || clan < 0)
            {
                return BadRequest("Nevalidna imena");
            }
            try{
                var clann = Context.clans
                            .Where(p=>p.ClanID==clan).FirstOrDefault();
                if(clann!=null)
                {
                    if(dolazak == 1) clann.dolasci = clann.dolasci + dolazak;
                    else clann.dolasci=clann.dolasci-1;
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno izmenjen dolazak na probe!");
                }
                else return BadRequest("Nije pronadjen clan!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DodajClana")]
        [HttpPost]
        public async Task<ActionResult> DodajClan(string ime_kud, int ansambl, string im, string pr, int god, DateTime datu)
        {
            if (string.IsNullOrEmpty(im) || string.IsNullOrEmpty(pr) || string.IsNullOrEmpty(ime_kud) || ansambl < 0 || god < 8 || datu == null)
            {
                return BadRequest("Nevalidni pokusaj");
            }
            try{
                //provere
                var clann = new Clan();
                var ansambll = Context.ansambls
                .Where(p => p.ID_an == ansambl && p.kud.naziv_kud==ime_kud).FirstOrDefault();
                    clann.ansambl = ansambll;
                    clann.Ime_cl = im;
                    clann.Prezime_cl =pr;
                    clann.datumupisa = datu;
                    clann.dolasci = 0;
                    clann.godine_cl =god;
                var clanarine = Context.clanarinas;

                                Context.clans.Add(clann);
                
                int godinetest = int.Parse(datu.ToString("yyyy"));
                int mesectest = int.Parse(datu.ToString("MM"));
                int pom =0;
                if(godinetest==int.Parse(DateTime.Today.ToString("yyyy"))&& mesectest<=int.Parse(DateTime.Today.ToString("MM")))
                {
                    pom=mesectest-1;
                }
                foreach(var clanarina in clanarine)
                {
                    if(pom<=0)
                    {
                        Spoj spoj = new Spoj();
                        spoj.clan = clann;
                        spoj.clanarina = clanarina;
                        spoj.uplata = false;
                        Context.spojs.Add(spoj);
                    }
                    pom--;
                }
                await Context.SaveChangesAsync();
                return Ok("Dodate clanarine i clan");
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
        [Route("Ukloniclana")]
        [HttpDelete]
        public async Task<ActionResult> UkloniClan(string ime_kud, int ansambl, string ime, string prezime, DateTime datum)
        {
            if (string.IsNullOrEmpty(ime_kud) ) return BadRequest("Pogresno ste uneli ime kuda");
            if (string.IsNullOrEmpty(ime) ) return BadRequest("Pogresno ste uneli ime clana");
            if (string.IsNullOrEmpty(prezime) ) return BadRequest("Pogresno ste uneli prezime clana");
            if (datum==null ) return BadRequest("Niste uneli datum");
            try
            {
                var clan = Context.clans.Include(p=>p.ansambl.kud)
                                        .Where(p=>p.ansambl.kud.naziv_kud==ime_kud&&p.ansambl.ID_an==ansambl&&p.Ime_cl==ime&&p.Prezime_cl==prezime&&p.datumupisa==datum).FirstOrDefault();

                var spojevi = Context.spojs.Where(p=>p.clan.ClanID==clan.ClanID);
                foreach(var spoj in spojevi)
                {
                    Context.spojs.Remove(spoj);
                }
                Context.clans.Remove(clan);
                await Context.SaveChangesAsync();
                return Ok("Uspesno obrisano sve");      
            } 
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
        [Route("Premesti")]
        [HttpPut]
        public async Task<ActionResult> Premesti(string ime_kud, int ansambl, string ime, string prezime,int godine, DateTime datum)
        {
            if (string.IsNullOrEmpty(ime_kud) ) return BadRequest("Pogresno ste uneli ime kuda");
            if (string.IsNullOrEmpty(ime) ) return BadRequest("Pogresno ste uneli ime clana");
            if (string.IsNullOrEmpty(prezime) ) return BadRequest("Pogresno ste uneli prezime clana");
            if (datum==null ) return BadRequest("Niste uneli datum");
            var clan = Context.clans.Include(p=>p.ansambl)
                                    .ThenInclude(p=>p.kud)
                                    .Where(p=>p.ansambl.kud.naziv_kud==ime_kud&&p.Ime_cl==ime&&p.Prezime_cl==prezime&&p.datumupisa==datum&&p.godine_cl==godine).FirstOrDefault();
            var ansambll = Context.ansambls.Include(p=>p.kud)
                                    .Where(p=>p.kud.naziv_kud==ime_kud&&p.ID_an==ansambl).FirstOrDefault();
            clan.ansambl=ansambll;
            await Context.SaveChangesAsync();
            return Ok("Upseno promenjen ansambl");

        }

        [Route("Resetuj")]
        [HttpPut]
        public async Task<ActionResult> Resetuj(string ime_kud, int ansambl)
        {
            if (string.IsNullOrEmpty(ime_kud) ) return BadRequest("Pogresno ste uneli ime kuda");
            var clanovi = Context.clans.Include(p=>p.ansambl)
                                        .ThenInclude(p=>p.kud)
                                        .Where(p=>p.ansambl.ID_an == ansambl && p.ansambl.kud.naziv_kud == ime_kud);
            foreach(var clan in clanovi)
            {
                clan.dolasci=0;
            }
            await Context.SaveChangesAsync();
            return Ok("Upseno promenjen ansambl");

        }
    } 
    
}
