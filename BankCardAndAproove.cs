using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankSistem
{
    internal class BankCardAndAproove
    {

        public string CardNumber { get; protected set; }
        public string Password { get; protected set; }
        public double Balance { get; protected set; }
        public List<string> History { get; set; }

        public BankCardAndAproove(string cardNumber, string password, double balance)
        {

            CardNumber = cardNumber;
            Password = password;
            Balance = balance;
            History = new List<string>();
        }


    }

}


