using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Controllers;
using BankApi.data;

namespace BankApi.models
{
    public class Transaction
    {

    public int Id { get; set; }
    public int SenderId { get; set; }
    public Person? Sender { get; set; }
    public int ReceiverId { get; set; }
    public Person? Receiver { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    }
}