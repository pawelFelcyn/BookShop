using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCategoryService _service;

        public BookCategoriesController(IBookCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BookCategoryDto>> GetAll()
        {
            var categories = _service.GetAll();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult<BookCategoryDto> GetById([FromRoute] int id)
        {
            var category = _service.GetById(id);

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<BookCategoryDto> Create([FromBody] CreateBookCategoryDto dto)
        {
            var category = _service.Create(dto);

            return Created($"api/BookCategories/{category.Id}", category);
        }

        [HttpPut("{id}")]
        public ActionResult<BookCategoryDto> Update([FromBody] UpdateBookCategoryDto dto, [FromRoute] int id)
        {
            var category = _service.Update(dto, id);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
