using Microsoft.AspNetCore.Mvc;


public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }//ef

    public IActionResult Add()
    {
        return View();
    }//ef

    public IActionResult Edit()
    {
        return View();
    }//ef
    
    #region ACTIONS
    

    #endregion

}//ec
