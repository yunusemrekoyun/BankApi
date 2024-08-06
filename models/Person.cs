using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public decimal Balance { get; set; }

    }
}