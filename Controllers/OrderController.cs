using GraduaitionProjectITI.Reprository.OrderReprository;
using GraduaitionProjectITI.Reprository.SubOrderReprository;
using Microsoft.AspNetCore.Mvc;

namespace GraduaitionProjectITI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReprository reprositry;
        private readonly ISubOrderReprository reprositrySubOrder;
        public OrderController(IOrderReprository reprositry, ISubOrderReprository reprositrySubOrder)
        {
            this.reprositry = reprositry;
            this.reprositrySubOrder = reprositrySubOrder;
        }
        public IActionResult Index()
        {
            return View(this.reprositry.GetAll());
        }
        public IActionResult Details(int Id)
        {
            return View(this.reprositrySubOrder.GetSubOrderForOrder(Id));

        }
    }
}
