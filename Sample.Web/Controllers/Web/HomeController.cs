using Sample.Core.MongoDb;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMongoDbContext _mongoContext;

        public HomeController(IMongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        //
        // GET: /Root/

        public ActionResult Index()
        {
            return View();
        }

    }
}
