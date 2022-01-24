using System;
using System.Collections.Generic;
using System.Text;


namespace BenDeductionApi
{
    public class Beneficiary : IBeneficiary
    {
        public string BenficiaryName { get; set; }
        public decimal DefaultYearlyDeduction { get; set; }     
        public decimal YearlyDeductionAfterDiscount => BenficiaryName.ToUpper().StartsWith("A") ? DefaultYearlyDeduction * 0.9m : DefaultYearlyDeduction;     
    }

    public class Employee : IEmployee
    {
        public int YearlyPayStubCount { get; set; }
        public decimal MonthlySalary { get; set; }
        public string BenficiaryName { get; set; }
        public decimal DefaultYearlyDeduction { get; set; }
        public decimal YearlyDeductionAfterDiscount => BenficiaryName.ToUpper().StartsWith("A") ? DefaultYearlyDeduction * 0.9m : DefaultYearlyDeduction;       
    }

}
