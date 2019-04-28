using Microsoft.AspNetCore.Mvc;
using Marketplace.DbAccess;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class DiscountController
    {
        private readonly IUnitOfWork unitOfWork;

        public DiscountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }    
    }
}