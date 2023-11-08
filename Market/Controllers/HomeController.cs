using Market.Data.Interfaces;
using Market.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductInterface.GetAllAsync();
            var categories = await _unitOfWork.ProductCategoryInterface.GetAllAsync();
            var receipts = await _unitOfWork.ReceiptInterface.GetAllAsync();
            return View();
        }
    }
}