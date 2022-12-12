using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public partial class LoanRequestModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string businessNumber { get; set; }
        public decimal loanAmount { get; set; }
        public string citizenshipStatus { get; set; }
        public string timeTrading { get; set; }
        public string countryCode { get; set; }
        public string industry { get; set; }
    }
}
