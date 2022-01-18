using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KategorijaController : ControllerBase
    {
        public ReceptContext Context { get; set; }

        public KategorijaController(ReceptContext context)
        {
            Context = context;
        }

        [Route("PreuzmiKategorije")]
        [HttpGet]
        public async Task<ActionResult> Kategorije()
        {
            try
            {
                return Ok(await Context.Kategorije.Select(p =>
                new
                {
                    ID = p.ID,
                    Naziv = p.Naziv
                    
                }).ToListAsync());
            }
            catch(Exception exc)
            {
                return BadRequest("Greška pri komunikaciji sa bazom! " + exc.Message);
            }
        }

        [Route("PreuzmiTip")]
        [HttpGet]
        public async Task<ActionResult> Tipovi()
        {
            try
            {
                return Ok(await Context.Tipovi.Select(p =>
                new
                {
                    ID = p.ID,
                    Naziv = p.TipJela
                    
                }).ToListAsync());
            }
            catch(Exception exc)
            {
                return BadRequest("Greška pri komunikaciji sa bazom! " + exc.Message);
            }
        }

        [Route("PreuzmiTezinu")]
        [HttpGet]
        public async Task<ActionResult> Tezine()
        {
            try
            {
                return Ok(await Context.TezinePripreme.Select(p =>
                new
                {
                    ID = p.ID,
                    Naziv = p.Tezina
                    
                }).ToListAsync());
            }
            catch(Exception exc)
            {
                return BadRequest("Greška pri komunikaciji sa bazom! " + exc.Message);
            }
        }

    }
}