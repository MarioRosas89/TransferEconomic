using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using TransferEconomic.Data;
using MailKit.Net.Smtp;

namespace TransferEconomic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Schedules>> Post([FromBody] Schedules schedule)
        {
            try
            {
                await _scheduleRepository.CreateSchedule(schedule);
                if (!string.IsNullOrEmpty(schedule.Email))
                {
                    Utils.SendWhatsapp("Se reservo con correo" + schedule.Email);
                    //Send email to client
                    Utils.sendEmail(schedule.Email, $"<h1>Confirmacion reserva<h1> <p>Desde:{schedule.From}");
                    //Send email to driver
                    Utils.sendEmail("mrosasg103@gmail.com", $"<h1>Confirmacion reserva<h1> <p>Desde:{schedule.From}");
                }
               
                return schedule;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data" + ex.Message);
            }
        }
    }
}
