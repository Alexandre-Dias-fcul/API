using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Extensions;
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

        [HttpGet("{id:int}")] 
        public ActionResult<ListingDto> GetById(int id) 
        {
            return Ok(_listingService.GetById(id));
        }

        [HttpPost]
        public ActionResult<ListingDto> Add([FromBody] CreateListingDto createListingDto) 
        {
            string? id = User.GetId();

            if (id == null)
            {
                return BadRequest("Não está autenticado como empregado.");
            }

            int agentId = int.Parse(id);

            CreateListingServiceDto createListingServiceDto = new()
            {
                Type = createListingDto.Type,
                Status = createListingDto.Status,
                NumberOfRooms = createListingDto.NumberOfRooms,
                NumberOfKitchens = createListingDto.NumberOfKitchens,
                NumberOfBathrooms = createListingDto.NumberOfBathrooms,
                Price = createListingDto.Price,
                Location = createListingDto.Location,
                Area = createListingDto.Area,
                Parking = createListingDto.Parking,
                Description = createListingDto.Description,
                MainImageFileName = createListingDto.MainImageFileName,
                OtherImagesFileNames = createListingDto.OtherImagesFileNames,
                AgentId = agentId
            };

            return Ok(_listingService.Add(createListingServiceDto));
        }

        [HttpPost("SelfReassign/{listingId:int}")] 
        public ActionResult<ReassignDto> SelfReassign(int listingId) 
        {
            var agentIdString = User.GetId();

            if (agentIdString == null)
            {
                return NotFound("Não está autenticado.");
            }

            var agentId = int.Parse(agentIdString);

            return Ok(_listingService.SelfReassign(listingId, agentId));
        }

        [HttpPost("SelfReassignTo/{listingId:int}/{agentId:int}")]
        public ActionResult<ReassignDto> SelfReassignTo(int listingId,int agentId)
        {
            return Ok(_listingService.SelfReassignTo(listingId, agentId));
        }

        [HttpPost("BetweenReassign/{listingId:int}/{agentId:int}")]
        public ActionResult<ReassignDto> BetweenReassign(int listingId,int agentId)
        {
            return Ok(_listingService.BetweenReassign(listingId, agentId));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ListingDto> Update([FromRoute] int id,[FromBody] ListingDto listingDto) 
        {
            if(id != listingDto.Id) 
            {
                return BadRequest("Os ids da listing não coincidem.");   
            }

            return Ok(_listingService.Update(listingDto));
        }
    }
}
