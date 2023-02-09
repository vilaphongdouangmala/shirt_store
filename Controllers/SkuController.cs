using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SkuController : Controller
{
    private readonly ILogger<SkuController> _logger;
    private ShirtstoreDbContext _db;

    public SkuController(ILogger<SkuController> logger, ShirtstoreDbContext db)
    {
        _db = db;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var result = _db.Sku
            .Include(x => x.Color)
            .Include(x => x.Size)
            .Include(x => x.Product)
            .ThenInclude(x => x.ProductCategory)
            .ToList();
        
        //Utilization of viewbag for server-side data binding
        ViewBag.skus = result;
        return View(result);
    }

    public IActionResult Add() {
        return View();
    }//ef

    #region ACTIONS

    #endregion

}//ec
