using Microsoft.AspNetCore.Mvc;
using Mission09_sk389.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentRepository repo { get; set; }
        private Basket basket { get; set; }
        public PaymentController(IPaymentRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Payment());
        }

        //Recieve the Payment and send to database
        [HttpPost]
        public IActionResult Checkout(Payment payment)
        {
            //Check to see if basket is empty, if not, continue
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                payment.Lines = basket.Items.ToArray();
                repo.SavePayment(payment);
                basket.ClearBasket();
                return RedirectToPage("/PaymentConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
