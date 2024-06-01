using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybank
{
    public class Transcations
    {
        public decimal Amt { get; }
        public DateTime Date { get; }
        public string note {  get; }

        public Transcations(decimal amount, DateTime date, string Note)
        {
            this.Amt = amount;
            this.Date = date;
            this.note = Note;

        }
    }
}
