﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSquadBank
{
    public class BankLoan
    {
        public double Loan(double totalLoan)
        {
            totalLoan = totalLoan * 1.3;
            return totalLoan;
        }
    }
}
