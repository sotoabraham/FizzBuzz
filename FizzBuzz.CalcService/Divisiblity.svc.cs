using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace FizzBuzz.CalcService
{
    [ServiceContract(Namespace = "FizzBuzz.CalcService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Divisiblity
    {
        [OperationContract]
        [WebGet]
        public String ServiceTest()
        {
            return "FizzBuzz.CalcService is running.";
        }

        [OperationContract]
        [WebGet]
        public String Divisibility(List<Object> dividends, Int32 firstDivisor, Int32 secondDivisor)
        {
            Int32 lowerDivisor;
            Int32 higherDivisor;
            
            StringBuilder detail = new StringBuilder();
            StringBuilder summary = new StringBuilder();

            if (firstDivisor >= secondDivisor)
            {
                lowerDivisor = firstDivisor;
                higherDivisor = secondDivisor;
            }
            else
            {
                lowerDivisor = secondDivisor;
                higherDivisor = firstDivisor;
            }

            foreach (object dividendObject in dividends)
            {
                try
                {
                    Int32 dividend = Convert.ToInt32(dividendObject);

                    if (dividend % lowerDivisor == 0)
                    {
                        summary.Append("Fizz");
                        detail.AppendLine("Divided: " + dividend + " by: " + lowerDivisor);
                    }

                    if (dividend % higherDivisor == 0)
                    {
                        summary.Append("Buzz");
                        detail.AppendLine("Divided: " + dividend + " by: " + higherDivisor);
                    }

                    summary.AppendLine();
                }
                catch (Exception)
                {
                    detail.AppendLine(dividendObject.GetType().ToString() + " - N/A");
                    //throw;
                }
            }

            return summary.ToString() + detail.ToString();
        }
    }
}
