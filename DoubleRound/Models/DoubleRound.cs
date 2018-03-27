using System;
using DoubleRound.Models.Contracts;

namespace DoubleRound.Models
{
    public class DoubleRound
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public IProvider Provider { get; set; }
    }
}