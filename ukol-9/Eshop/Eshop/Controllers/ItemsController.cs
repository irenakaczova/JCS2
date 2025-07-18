using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eshop.Entities;

namespace Eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly EshopContext _context;

        public ItemsController(EshopContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemBasicDto>>> GetItems()
        {
            return await _context.Items.Select(x => ItemToBasicDto(x)).ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return ItemToDto(item);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPostDto>> PostItem(ItemPostDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                SoldDate = itemDto.SoldDate
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, ItemToBasicDto(item));
        }

        private static ItemBasicDto ItemToBasicDto(Item item) =>
           new ItemBasicDto
           {
               Id = item.Id,
               Name = item.Name,
           };

        private static ItemDto ItemToDto(Item item) =>
           new ItemDto
           {
               Id = item.Id,
               Name = item.Name,
               PriceList = item.PriceList,
               Customers = item.Customers,
               SoldDate = item.SoldDate
           };
    }
}
