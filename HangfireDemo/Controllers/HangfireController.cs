using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        // fire and forget
        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendMessage("Welcome to using this app"));
            return Ok($"Job ID: {jobId}. The welcome message has been sent to the user.");
        }

        // delayed jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            double timeToDelay = 30.0;
            var jobId = BackgroundJob.Schedule(() => SendMessage("The discount is waiting for you"), TimeSpan.FromSeconds(timeToDelay));
            return Ok($"Job ID: {jobId}. The discount message will be sent with {timeToDelay} seconds delay.");
        }

        // recurring jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult CheckNewData()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("New data comes."), Cron.Minutely);
            return Ok("New data check job started.");
        }

        // continuous jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Confirm()
        {
            //In this demo BackgroundJob.Schedule() is used, in real world here should be BackgroundJob.Enqueue()
            double timeToDelay = 30.0;
            var parentJobId = BackgroundJob.Schedule(() => SendMessage("You want to subscribe to our service."), TimeSpan.FromSeconds(timeToDelay));

            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("You are successfully subscribed!"));
            return Ok("Confirmation job is created!");
        }

        public void SendMessage(string body)
        {
            Console.WriteLine(body);
        }
    }
}
