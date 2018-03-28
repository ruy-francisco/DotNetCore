using Microsoft.AspNetCore.Mvc;
using DoubleRound.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using DoubleRound.CustomExceptions;

namespace DoubleRound.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DoubleRoundController: Controller
    {
        private readonly DoubleRoundApiContext _context;

        public DoubleRoundController(DoubleRoundApiContext context) {
            _context = context;
        }

        [HttpGet]
        public List<Models.DoubleRound> GetDoubleRounds() {
            try
            {
                var doubleRounds = _context.DoubleRounds.ToList();

                if (doubleRounds.Count == 0)
                    throw new ResultNotFoundException();

                return doubleRounds;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        [HttpGet("{date}")]
        public List<Models.DoubleRound> GetDoubleRoundsByPeriod(DateTime date) {
            try
            {
                DateTime initialPeriod = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                DateTime finalPeriod = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

                var doubleRounds = _context.DoubleRounds
                    .Where(dr => dr.BeginDate >= initialPeriod && dr.BeginDate <= finalPeriod) 
                    .OrderBy(dr => dr.BeginDate)
                    .ThenBy(dr => dr.EndDate)  
                    .ToList();

                if (doubleRounds.Count == 0)
                    throw new ResultNotFoundException();

                return doubleRounds;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetDoubleRoundById(int id) {
            try
            {
                var doubleRound = _context.DoubleRounds.First(d => d.Id == id);
                return new ObjectResult(doubleRound);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        [HttpPost]
        public IActionResult InsertDoubleRound([FromBody] Models.DoubleRound doubleRound){
            try
            {
                if (doubleRound == null)
                    return BadRequest();

                _context.DoubleRounds.Add(doubleRound);
                _context.SaveChanges();

                return CreatedAtRoute("GetById", new {id = doubleRound.Id }, doubleRound);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoubleRoundById(int id){
            try
            {
                var doubleRound = _context.DoubleRounds.FirstOrDefault(d => d.Id == id);

                if (doubleRound == null)
                    return NotFound();

                _context.DoubleRounds.Remove(doubleRound);
                _context.SaveChanges();

                return new NoContentResult();
            }
            catch (System.Exception)
            {                
                throw;
            }
        }

        [HttpDelete("{endDate}")]
        public IActionResult DeleteDoubleRoundsUntilDate(DateTime endDate) {
            try
            {
                DateTime finalDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                var doubleRounds = _context.DoubleRounds.Where(d => d.EndDate < finalDate).ToList();

                if (doubleRounds.Count == 0)
                    return NotFound();

                for (int i = 0; i < doubleRounds.Count; i++)
                    _context.DoubleRounds.Remove(doubleRounds[i]);
                
                _context.SaveChanges();

                return new NoContentResult();
            }
            catch (System.Exception)
            {                
                throw;
            }
        }
    }
}