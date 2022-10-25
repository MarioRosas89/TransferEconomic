using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransferEconomic.Data;

namespace TransferEconomic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly ILogger<TicketController> _logger;
        public TicketController(ApplicationDbContext context, ILogger<TicketController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ticket>> Get(string fromPlace, string toPlace)
        {
            var getPlaces = await _context.Places.Select(p => p).ToListAsync();
            var fromId = getPlaces.SingleOrDefault(x => x.Name == fromPlace);
            var toId = getPlaces.SingleOrDefault(x => x.Name == toPlace);
            
            if (fromId == null || toId == null)
                return NotFound();
            var list = await _context.Tickets.Where(x => x.FromIdPlace == fromId.Id && x.ToIdPlace == toId.Id).ToListAsync();
            return CreatedAtAction(nameof(list), list);
        }


    }
}
