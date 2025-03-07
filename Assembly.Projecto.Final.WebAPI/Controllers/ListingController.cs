using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public ActionResult<List<ListingDto>> GetAll() 
        {
            var listings = _listingService.GetAll();

            return Ok(listings);
        }

        [HttpPost] 
        public ActionResult<ListingDto> Create([FromBody] ListingDto listingDto)  
        {
            var listing = _listingService.Add(listingDto);

            return Ok(listing);
        }

        [HttpPut]
        public ActionResult<ListingDtoId> Update([FromBody] ListingDtoId listingDtoId) 
        {
            var listing = _listingService.Update(listingDtoId);

            return Ok(listing);
        }
    }
}
