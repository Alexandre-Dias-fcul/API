using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class ListingController:BaseController
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService) 
        {
            _listingService = listingService;
        }

        [HttpGet]
        public IEnumerable<ListingDto> GetAll() 
        {
            return _listingService.GetAll();
        }

        [HttpGet("{id:int")] 
        public ActionResult<ListingDto> GetById(int id) 
        {
            return Ok(_listingService.GetById(id));
        }

        [HttpPost]
        public ActionResult<ListingDto> Add([FromBody] CreateListingDto createListingDto) 
        {
            return Ok(_listingService.Add(createListingDto));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ListingDto> Update([FromRoute] int id,[FromBody] ListingDto listingDto) 
        {
            if(id != listingDto.Id) 
            {
                 return BadRequest("Os ids da listing não coincidem.")   
            }

            return Ok(_listingService.Update(listingDto));
        }
    }
}
