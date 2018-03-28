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
                    .Where(dr => dr.Begin >= initialPeriod && dr.Begin <= finalPeriod)   
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
    }
}