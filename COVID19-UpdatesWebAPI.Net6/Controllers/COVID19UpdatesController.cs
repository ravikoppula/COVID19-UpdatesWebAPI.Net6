using Microsoft.AspNetCore.Mvc;

namespace COVID19_UpdatesWebAPI.Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COVID19UpdatesController : Controller
    {
        #region Constructor

        private readonly ICOVID19UpdatesService _covidUpdatesService;
        public COVID19UpdatesController(ICOVID19UpdatesService covidUpdatesService)
        { 
            _covidUpdatesService = covidUpdatesService;
        }


        #endregion

        #region View Dashboard

        [HttpGet]
        [Route("getupdates")]
        public IActionResult GetCOVID19Updates()
        {
            return View();
        }

        #endregion 


        #region Set Input Parms

        [HttpGet("{id}")]
        [Route("getcovid19updates")]
        public ActionResult<IEnumerable<COVID19UpdatesVM>> GetCOVID19Updates(string? country, string? state, DateTime lastUpdatedDate)
        {
            try
            {
                var covidUpdateList = _covidUpdatesService.GetCOVID19Cases(country, state, lastUpdatedDate);
                return covidUpdateList;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAllOwners action: {ex.Message}");
            }
        }

        #endregion 


    }
}
