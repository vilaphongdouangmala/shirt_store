using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderController : Controller
{
    private ShirtstoreDbContext _db;
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger, ShirtstoreDbContext db)
    {
        _db = db;
        _logger = logger;
    }
    public IActionResult Index()
    {

        //ViewBag
        return View();
    }//ef

    public IActionResult Add()
    {
        return View();
    }//ef

    #region ACTIONS

    #endregion
    
}//ec
