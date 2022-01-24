using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenDeductionApi
{
    public static class BenefitDeductionCalculator
    {       
        public static decimal GetTotalDeduction(Employee objEmp, List<Beneficiary> objBen,out decimal monthlySalAfterDeduction)
        {
            decimal totalMonthlyDeduction = 0m;
            monthlySalAfterDeduction = 0m;

            totalMonthlyDeduction = (objEmp.YearlyDeductionAfterDiscount + objBen.Sum(x => x.YearlyDeductionAfterDiscount)) 
                                            / objEmp.YearlyPayStubCount;
            monthlySalAfterDeduction = objEmp.MonthlySalary - totalMonthlyDeduction;

            return totalMonthlyDeduction;
        }

    }
}
