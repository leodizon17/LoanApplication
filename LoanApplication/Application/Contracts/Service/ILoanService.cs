using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Service
{
    public interface ILoanService
    {
        Task<ResultModel> AddLoanApplication(LoanRequestModel items);
    }
}
