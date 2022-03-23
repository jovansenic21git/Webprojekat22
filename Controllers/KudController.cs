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
    public class KudController : ControllerBase
    {
        public KudContext Context {get; set;}
        public KudController(KudContext context) => Context = context;

        [Route("DodajKud/{nz}/{adr}/{mes}")]
        [HttpPost]
        public async Task<ActionResult> DodajKud(string nz, string adr, string mes)
        {
            if(string.IsNullOrWhiteSpace(nz) || nz.Length>100)
            {
                return BadRequest("Lose unet naziv kuda!");
            }
            if(string.IsNullOrWhiteSpace(adr) || adr.Length>150)
            {
                return BadRequest("Lose uneta adresa kuda!");
            }
            if(string.IsNullOrWhiteSpace(mes) || mes.Length>150)
            {
                return BadRequest("Lose uneto mesot kuda!");
            }
            try{
                var kud = new Kud();
                kud.naziv_kud=nz;
                kud.mesto=mes;
                kud.Adresa=adr;
                Context.kuds.Add(kud);
                await Context.SaveChangesAsync();
                return Ok($"Ispravno dodat kud! ID : {kud.ID}");
            }
            catch(Exception e)
            {return BadRequest(e.Message);}
        }
        /*[Route("PreuzmiKud/{id}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKud(int id)
        {
            var kudovi = Context.kuds
                        .Where(p=>p.ID==id).ToList();

            
            return Ok(kudovi);
        }*/
    }
}