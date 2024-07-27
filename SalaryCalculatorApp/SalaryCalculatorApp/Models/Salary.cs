using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorApp.Models
{
    public class Salary
    {
        public double SalarayWithoutDeductions { get; set; }

        public double OtherIncome { get; set; }

        public double ReimbursableExpenses { get; set; }

        public double AsociacionPercentage { get; set; }

        public double ComplementaryPension { get; set; }

        public double Deductions => CalculateDeductions();

        public double CalculateDeductions()
        {
            Deductions deductions = new Deductions(SalarayWithoutDeductions + OtherIncome, AsociacionPercentage / 100);

            return deductions.CCSSDeduction + (double)deductions.CostaRixanISRDeduction() + deductions.AsosacionSolidaristaDeduction;
        }

        
        public double NetIncome => (SalarayWithoutDeductions + OtherIncome + ReimbursableExpenses - Deductions - ComplementaryPension);
    
    }


}
