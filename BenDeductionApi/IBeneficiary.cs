using System;
using System.Collections.Generic;
using System.Text;

namespace BenDeductionApi
{
    public interface IBeneficiary
    {
        string BenficiaryName { get; set; }
        decimal DefaultYearlyDeduction { get; set; }
        decimal YearlyDeductionAfterDiscount { get; }        
    }

    public interface IEmployee : IBeneficiary
    {
       decimal MonthlySalary { get; set; }
       int YearlyPayStubCount { get; set; }
    }
}
