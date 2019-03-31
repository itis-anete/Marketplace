using MarketPlace.DbAccess;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Web.Controllers
{
    public class MarketController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MarketController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        
    }
}