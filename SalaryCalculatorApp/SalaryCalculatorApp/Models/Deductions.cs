using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorApp.Models
{
    public class Deductions
    {
        public double _taxSalary;
        public double _asociacionPercentage;
        public Deductions(double taxSalary, double asociacionPercentage = 0)
        {
            _taxSalary = taxSalary;
            _asociacionPercentage = asociacionPercentage;
        }

        public double CCSSDeduction => (double)(_taxSalary * 0.0967);

        public decimal CostaRixanISRDeduction()
        {
            decimal tax = 0;
            decimal taxSalary = (decimal)_taxSalary;

            if (taxSalary <= 863000)
            {
                tax = 0;
            }

            else if (_taxSalary <= 1267000)
            {
                tax = (taxSalary - 863000) * 0.10m;
            }
            else if (_taxSalary <= 2223000)
            {
                tax = (1267000 - 863000) * 0.10m + (taxSalary - 1267000) * 0.15m;
            }
            else if (_taxSalary <= 4445000)
            {
                tax = (1267000 - 863000) * 0.10m + (2223000 - 1267000) * 0.15m + (taxSalary - 2223000) * 0.20m;
            }
            else
            {
                tax = (1267000 - 863000) * 0.10m + (2223000 - 1267000) * 0.15m + (4445000 - 2223000) * 0.20m + (taxSalary - 4445000) * 0.25m;
            }

            return tax;
        }


        public double AsosacionSolidaristaDeduction => _asociacionPercentage != 0 ?  (double)(_taxSalary * _asociacionPercentage) : 0;
    }
}
