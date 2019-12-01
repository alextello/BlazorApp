using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class PersonaService
    {
        private readonly AppDBContext _context;
        public PersonaService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(int Id)
        {
            return await _context.Personas.FindAsync(Id); ;
        }

        public async Task<Persona> InsertPersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona> UpdatePersonaAsync(int Id, Persona persona)
        {
            var per = await _context.Personas.FindAsync(Id);
            if(per == null)
            {
                return null;
            }

            per.Nombre  = persona.Nombre;
            per.FechaNacimiento = persona.FechaNacimiento;
            _context.Personas.Update(per);
            await _context.SaveChangesAsync();

            return persona;
        }

        public async Task<Persona> DeletePersonaAsync(int Id)
        {
            var persona = await _context.Personas.FindAsync(Id);

            if(persona == null)
            {
                return null;
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;

        }

        private bool PersonaExiste(int Id)
        {
            return _context.Personas.Any(x => x.Id == Id);
        }
    }
}
