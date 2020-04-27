using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication10.Controllers.Resource;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Route("api/Camp")]
    public class CampgroundController : ApiController
    {
        private readonly CampDbContext context;
        public CampgroundController()
        {
            context = new CampDbContext();
        }

        //Get /api/Camp
        [HttpGet]
        public async Task<IEnumerable<CampgroundResource>> Getcampgrounds()
        {
            var camps = await context.campgrounds.ToListAsync();
            return Mapper.Map<List<Campground>, List<CampgroundResource>>(camps);
        }

       // post : /api/Campground
       


        [HttpPost]
        public async Task<IHttpActionResult> CreateCampground([FromBody] CampgroundResource campgroundResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var camps = Mapper.Map<CampgroundResource, Campground>(campgroundResource);
            context.campgrounds.Add(camps);
            await context.SaveChangesAsync();
            var result = Mapper.Map<Campground, CampgroundResource>(camps);
            return Ok(result);

        }




        //[HttpPost]
        //public List<Campground> Postcampgrounds(DateTime checkin)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //    //List<Booking> camps = context.bookings.Where(x => x.CheckOut < checkin).ToList();
        //    List<int> cid = context.bookings.Where(y => y.CheckOut < checkin).Select(x => x.C_Id).ToList();
        //    List<int> cid1 = context.campgrounds.Select(x => x.C_Id).ToList();
        //    var finalcid = cid1.Except(cid);
        //    List<Campground> result = new List<Campground>();
        //    foreach (int id in finalcid)
        //    {
        //        Campground cid2 = context.campgrounds.FirstOrDefault(x=>x.C_Id==id);
        //        result.Add(cid2);
        //    }
        //    return result;

        //}
    }
}
