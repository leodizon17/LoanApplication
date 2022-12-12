using Application.Contracts.Service;
using Application.Exceptions;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features
{
    public class LoanService : ILoanService
    {
        public async Task<ResultModel> AddLoanApplication(LoanRequestModel items)
        {
            ResultModel result = new ResultModel();
            string[] industries = new string[]
            {
                "Industry 1",
                "Industry 2",
                "Industry 3",
                "Banned Industry 1",
            };

            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (items.firstName == null || items.lastName == null) result.decision = "Unqualified";
            if (items.emailAddress == null || items.phoneNumber == null) result.decision = "Unqualified";
            else if (!(items.citizenshipStatus == "Citizen" || items.citizenshipStatus == "Permanent Resident")) result.decision = "Unqualified";
            else if (!(isNumber(items.timeTrading) && (int.Parse(items.timeTrading) >= 1 && int.Parse(items.timeTrading) <= 20))) result.decision = "Unqualified";
            else if (items.countryCode.ToUpper() != "AU") result.decision = "Unqualified";
            else result.decision = "Qualified";

            if (items.phoneNumber.Substring(0, 2) == "04" || items.phoneNumber.Substring(0, 2) == "02" || items.phoneNumber.Substring(0, 2) == "03" || items.phoneNumber.Substring(0, 2) == "07" || items.phoneNumber.Substring(0, 2) == "08" || items.phoneNumber.Substring(0, 4) == "+614")
            {
                string phone = "";
                if (items.phoneNumber.Length == 10)
                {
                    phone = items.phoneNumber.Substring(2, items.phoneNumber.Length - 2);
                }

                if (items.phoneNumber.Length == 12)
                {
                    phone = items.phoneNumber.Substring(4, items.phoneNumber.Length - 4);
                }

                if (phone.Length == 8)
                {
                    if (!isNumber(phone))
                    {
                        ValidationResult validationResult = new ValidationResult();
                        result.decision = "Unqualified";
                        validationResult.rule = "phoneNumber";
                        validationResult.message = "Invalid Phone number format";
                        validationResult.decision = "Unknown";
                        validationResults.Add(validationResult);
                    }
                }
                else
                {
                    ValidationResult validationResult = new ValidationResult();
                    result.decision = "Unqualified";
                    validationResult.rule = "phoneNumber";
                    validationResult.message = "Invalid Phone number format";
                    validationResult.decision = "Unknown";
                    validationResults.Add(validationResult);
                }
            }
            else
            {
                ValidationResult validationResult = new ValidationResult();
                result.decision = "Unqualified";
                validationResult.rule = "phoneNumber";
                validationResult.message = "Invalid Phone number format";
                validationResult.decision = "Unknown";
                validationResults.Add(validationResult);
            }

            if (items.businessNumber.Length != 11 || !isNumber(items.businessNumber))
            {
                ValidationResult validationResult = new ValidationResult();
                result.decision = "Unqualified";
                validationResult.rule = "businessNumberRule";
                validationResult.message = "Incorrect Business Number";
                validationResult.decision = "Unqualified";
                validationResults.Add(validationResult);
            }
            
            if (!(items.loanAmount >= Convert.ToDecimal("10.00") && items.loanAmount <= Convert.ToDecimal("100.00")))
            {
                ValidationResult validationResult = new ValidationResult();
                result.decision = "Unqualified";
                validationResult.rule = "loanAmount";
                validationResult.message = "Loan Amount is invalid";
                validationResult.decision = "Unknown";
                validationResults.Add(validationResult);
            }

            foreach(var industry in industries)
            {
                if(industry.Contains(items.industry) && industry.Contains("Banned"))
                {
                    result.decision = "Unqualified";
                }
                else if(industry.Contains(items.industry) && !industry.Contains("Banned"))
                {
                    result.decision = "Qualified";
                    break;
                }
                else
                {
                    result.decision = "Unknown";
                }
            }

            result.validationResult = validationResults;

            return result;
        }

        private bool isNumber(string number)
        {
            Regex regexInt = new Regex("^\\d+$");

            bool isNumber = regexInt.IsMatch(number);

            return isNumber;
        }

      
    }
}
