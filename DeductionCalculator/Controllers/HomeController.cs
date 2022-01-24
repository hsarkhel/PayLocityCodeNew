using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDeductionApi;
using System.Configuration;
using System.Text;

namespace DeductionCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Result = "";
            return View();
        }

       [HttpPost]
        public ActionResult Index(FormCollection fcEmp)
        {
            string names = fcEmp["txtBen"];
            decimal empYearlyDeduction = 0m;
            decimal depYearlyDeduction = 0m;
            decimal monthlySal = 0m;
            int yearlyPayStubCount = 0;

            decimal monthlyDeduction = 0m;
            decimal salAfterDeduction = 0m;

            Employee objEmp = new Employee();
            Beneficiary objBen;
            List<Beneficiary> objBenList = new List<Beneficiary>();

            decimal.TryParse(ConfigurationManager.AppSettings["EmpYearlyDeduction"], out empYearlyDeduction);
            decimal.TryParse(ConfigurationManager.AppSettings["DepYearlyDeduction"], out depYearlyDeduction);
            decimal.TryParse(ConfigurationManager.AppSettings["MonthlySal"], out monthlySal);
            int.TryParse(ConfigurationManager.AppSettings["YearlyPayStubCount"], out yearlyPayStubCount);

            foreach(string name in names.Split(','))
            {
                if(objEmp.BenficiaryName is null)
                {
                    objEmp.BenficiaryName = name;
                    objEmp.DefaultYearlyDeduction = empYearlyDeduction;
                    objEmp.MonthlySalary = monthlySal;
                    objEmp.YearlyPayStubCount = yearlyPayStubCount;
                }
                else
                {
                    objBen = new Beneficiary() { BenficiaryName = name, DefaultYearlyDeduction = depYearlyDeduction };
                    objBenList.Add(objBen);
                    objBen = null;
                }
            }


            monthlyDeduction = BenefitDeductionCalculator.GetTotalDeduction(objEmp, objBenList, out salAfterDeduction);


            StringBuilder objResult = new StringBuilder();

            objResult.AppendLine("===================  " + objEmp.BenficiaryName + "'s Paycheck  ===================");
            objResult.AppendLine(" Salary Before Deductions : $ " + monthlySal.ToString("#.##"));
            objResult.AppendLine(" Benefit Deduction        : $ " + monthlyDeduction.ToString("#.##") + " ( No of dependent # " + objBenList.Count.ToString() + " )");
            objResult.AppendLine("-------------------------------------------------------------------------");
            objResult.AppendLine(" Salary After Deduction   : $ " + salAfterDeduction.ToString("#.##") );

            ViewBag.Result = objResult.ToString();
            

            return View();
        }
    }
}