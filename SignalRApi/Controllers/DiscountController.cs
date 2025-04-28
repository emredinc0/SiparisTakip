using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mappper;

        public DiscountController(IDiscountService discountService, IMapper mappper)
        {
            _discountService = discountService;
            _mappper = mappper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mappper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]

        public IActionResult DiscountContact(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
               Amount = createDiscountDto.Amount,
               Description = createDiscountDto.Description,
               
               Title =createDiscountDto.Title,
               ImageUrl = createDiscountDto.ImageUrl,

               

            });
            return Ok("İndirim Bilgisi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Silindi.");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                Amount = updateDiscountDto.Amount,

                Description = updateDiscountDto.Description,
                Id = updateDiscountDto.Id,
                Title = updateDiscountDto.Title,
                ImageUrl = updateDiscountDto.ImageUrl,

                

            });
            return Ok("İndirim Bilgisi Güncellendi.");
        }
    }
}
