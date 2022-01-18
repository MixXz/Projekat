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
    public class ReceptController : ControllerBase
    {
        public ReceptContext Context { get; set; }
        public ReceptController(ReceptContext context)
        {
            Context = context;
        }
        [Route("PreuzmiRecepte/{kategorijaID}")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi(int kategorijaID)
        {
            if(kategorijaID < 0)
                return BadRequest("Pogresan id kategorije!");
            try
            {
                var receptiPoKategoriji = Context.Recepti
                    .Include(p => p.Kategorija)
                    .Include(p => p.TezinaPripreme)
                    .Include(p => p.Tip)
                    .Where(p => p.Kategorija.ID == kategorijaID);

                var recepti = await receptiPoKategoriji.ToListAsync();

                return Ok
                (
                    recepti.Select(p =>
                    new
                    {
                        Id = p.ID,
                        Naziv = p.Naziv,
                        Opis = p.Opis,
                        Kategorija = p.Kategorija,
                        Sastojci = p.Sastojci,
                        Instrukcija = p.Instrukcija,
                        TezinaPripreme = p.TezinaPripreme,
                        VremePripreme = p.VremePripreme,
                        Tip = p.Tip,
                        slika = p.slika,

                    }).ToList()
                );
            }
            catch(Exception exc)
            {
                return BadRequest("Greska pri komunikaciji sa bazom! " + exc.Message);
            }
            
        }

        [Route("DodajRecept/{naziv}/{opis}/{kategorija}/{sastojci}/{instrukcija}/{tezina}/{vreme}/{slikica}/{tip}")]
        [HttpPost]
        public async Task<ActionResult> DodajRecept(string naziv, string opis,int kategorija, string sastojci, string instrukcija, int tezina, string vreme, string slikica, int tip)
        {
            if(string.IsNullOrWhiteSpace(naziv))
            {
                return BadRequest("Naziv jela ne može biti izostavljen!");
            }

            if(naziv.Length > 100)
            {
                return BadRequest("Naziv jela ne može biti duži od 100 karaktera!");
            }
            
            if(string.IsNullOrWhiteSpace(opis))
            {
                return BadRequest("Opis jela ne može biti izostavljen!");
            }

            if(opis.Length > 1000)
            {
                return BadRequest("Opis jela ne može biti duži od 1000 karaktera!");
            }

            if(string.IsNullOrWhiteSpace(sastojci))
            {
                return BadRequest("Sastojci jela ne mogu biti izostavljeni!");
            }

            if(sastojci.Length > 1000)
            {
                return BadRequest("Sastojci jela ne može biti duži od 1000 karaktera!");
            }

            if(tip < 0 || tip > 3)
            {
                return BadRequest("Nepostojeci tip!");
            }

            if(tezina < 0 || tezina > 3)
            {
                return BadRequest("Nepostojaca tezina!");
            }

            if(string.IsNullOrWhiteSpace(slikica))
            {
                return BadRequest("Slika ne moze biti izostavljena!");
            }
            var kat = await Context.Kategorije.Where(p => p.ID == kategorija).FirstOrDefaultAsync();
            var t = await Context.Tipovi.Where(p => p.ID == tip).FirstOrDefaultAsync();
            var tez = await Context.TezinePripreme.Where(p => p.ID == tezina).FirstOrDefaultAsync();

            try
            {
                Recept rec = new Recept 
                {
                    Naziv = naziv,
                    Opis = opis,
                    Kategorija = kat,
                    Sastojci = sastojci,
                    Instrukcija = instrukcija,
                    VremePripreme = vreme,
                    slika = slikica,
                    Tip = t,
                    TezinaPripreme = tez

                };
                Context.Recepti.Add(rec);
                await Context.SaveChangesAsync();
                return Ok("Recept je uspešno dodat u bazu podataka.");
            }
            catch(Exception exc)
            {
                return BadRequest("Došlo je do greške prilikom upisa u bazu podataka!" + exc.Message);
            }
            
        }

        [Route("PromenitiRecept/{id}/{naziv}/{opis}/{kategorija}/{sastojci}/{instrukcija}/{tezina}/{vreme}/{slikica}/{tip}")]
        [HttpPut]
        public async Task<ActionResult> Promeni(int id, string naziv, string opis, int kategorija, string sastojci, string instrukcija, int tezina, string vreme, string slikica, int tip)
        {
           if(string.IsNullOrWhiteSpace(naziv))
            {
                return BadRequest("Naziv jela ne može biti izostavljen!");
            }

            if(naziv.Length > 100)
            {
                return BadRequest("Naziv jela ne može biti duži od 100 karaktera!");
            }
            
            if(string.IsNullOrWhiteSpace(opis))
            {
                return BadRequest("Opis jela ne može biti izostavljen!");
            }

            if(opis.Length > 1000)
            {
                return BadRequest("Opis jela ne može biti duži od 1000 karaktera!");
            }

            if(string.IsNullOrWhiteSpace(sastojci))
            {
                return BadRequest("Sastojci jela ne mogu biti izostavljeni!");
            }

            if(sastojci.Length > 1000)
            {
                return BadRequest("Sastojci jela ne može biti duži od 1000 karaktera!");
            }

            if(tip < 0 || tip > 3)
            {
                return BadRequest("Nepostojeci tip!");
            }

            if(tezina < 0 || tezina > 3)
            {
                return BadRequest("Nepostojaca tezina!");
            }

            if(string.IsNullOrWhiteSpace(slikica))
            {
                return BadRequest("Slika ne moze biti izostavljena!");
            }
            
            try
            {
                var recept = Context.Recepti.Where(p => p.ID == id).FirstOrDefault();
                var kat = await Context.Kategorije.Where(p => p.ID == kategorija).FirstOrDefaultAsync();
                var t = await Context.Tipovi.Where(p => p.ID == tip).FirstOrDefaultAsync();
                var tez = await Context.TezinePripreme.Where(p => p.ID == tezina).FirstOrDefaultAsync();

                if(recept != null)
                {
                    recept.Naziv = naziv;
                    recept.Opis = opis;
                    recept.Kategorija = kat;
                    recept.Sastojci = sastojci;
                    recept.Instrukcija = instrukcija;
                    recept.TezinaPripreme = tez;
                    recept.VremePripreme = vreme;
                    recept.slika = slikica;
                    recept.Tip = t;

                    await Context.SaveChangesAsync();
                    return Ok($"Recept sa nazivom: {recept.Naziv} je uspešno izmenjen.");
                }
                else
                {
                    return BadRequest("Recept nije pronadjen!");
                }
                
            }
            catch(Exception exc)
            {
                return BadRequest("Greška prilikom izmene recepta! " + exc.Message);
            }
        }

        [Route("IzbrisatiRecept/{id}")]
        [HttpDelete]
        public async Task<ActionResult> izbrisi(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Nepostojeci ID!");
            }
            try
            {
                var recept = await Context.Recepti.FindAsync(id);

                if(recept != null)
                {
                    Context.Recepti.Remove(recept);
                    await Context.SaveChangesAsync();
                    return Ok("Recept je uspesno izbrisan.");
                }
                else
                {
                    return BadRequest("Recept nije pronadjen!");
                }
            }
            catch(Exception exc)
            {
                return BadRequest("Greska prilikom brisanja!" + exc.Message);
            }
        }
         
    }
}
