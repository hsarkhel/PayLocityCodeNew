using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDeductionApi;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee objEmp = new Employee() { BenficiaryName = "Hindol",DefaultYearlyDeduction = 1000m,MonthlySalary = 2000m,YearlyPayStubCount = 26  };


            List<Beneficiary> ObjBenLst = new List<Beneficiary>();

            Beneficiary objBen1 = new Beneficiary() { BenficiaryName = "Susmita", DefaultYearlyDeduction = 500m };
            ObjBenLst.Add(objBen1);

            Beneficiary objBen2 = new Beneficiary() { BenficiaryName = "Ashim", DefaultYearlyDeduction = 500m };
            ObjBenLst.Add(objBen2);

            Beneficiary objBen3 = new Beneficiary() { BenficiaryName = "Hrishi", DefaultYearlyDeduction = 500m };
            ObjBenLst.Add(objBen3);

            decimal salAftDeduc = 0m;

            decimal test = BenefitDeductionCalculator.GetTotalDeduction(objEmp, ObjBenLst, out salAftDeduc);

        }
    }
}
