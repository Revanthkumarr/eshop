using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybank
{
    public class Bankacct
    {
        
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal balance = 0;
                foreach (var item in alltrans)
                {
                    balance += item.Amt;
                }
                return balance;

            }
          
                }
        

        private static int accountseed=1234567890;

        private List<Transcations> alltrans=new List<Transcations>();
        public Bankacct(string owner, decimal initialBalance)
        {
            this.Number = accountseed.ToString();
            Makedeposit(initialBalance, DateTime.Now, "Initial balance");
            this.Owner = owner;
            accountseed++;
        }

        public void Makedeposit(decimal amount, DateTime datetime, string note)
        {
            if (amount<=0)
            {
                throw new ArgumentException("BAlance should be greater than o");
            }
            var deposit=new Transcations(amount, datetime, note);
            alltrans.Add(deposit);
            

        }
        public void Makewithdraw(decimal amount, DateTime datetime, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Withdrawl should be greater than o");
            }
            if(Balance-amount<=0)
            {
                throw new InvalidOperationException("Insufficent Funds");

            }
            var withdrawl = new Transcations(-amount, datetime, note);
            alltrans.Add(withdrawl);

        }

        public string Getapptrans()
        {

            var report =new StringBuilder();

            report.AppendLine("Date\t\t\tAmount\tNote");

            foreach(var item in alltrans)
            {
                report.AppendLine($"{item.Date}\t{item.Amt}\t{item.note}");
            }
            return report.ToString();


        }
        
    }
   
}
