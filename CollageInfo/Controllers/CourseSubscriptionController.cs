using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;
using CollageInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollageInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubscriptionController : ControllerBase
    {
        private readonly ICourseSubscriptionService _service;

        public CourseSubscriptionController(ICourseSubscriptionService service)
        {
            _service = service;
        }

        [HttpPost("AddCourseSubscription")]
        public async Task<IActionResult> AddCourseSubscription([FromBody] List<CourseSubscriptionModel> courseSubscription)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _service.AddCourseSubscription(courseSubscription);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database update error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllCourseSubscriptions")]
        public async Task<IActionResult> GetAllCourseSubscriptions()
        {
            var subscriptions = await _service.GetAllCourseSubscription();
            return Ok(subscriptions);
        }

        [HttpGet("GetCourseSubscriptionById")]
        public async Task<IActionResult> GetCourseSubscriptionById(int id)
        {
            var subscription = await _service.GetCourseSubscriptionById(id);
            if (subscription == null)
            {
                return NotFound($"CourseSubscription with ID {id} not found.");
            }
            return Ok(subscription);
        }

        [HttpPut("UpdateCourseSubscription")]
        public async Task<IActionResult> UpdateCourseSubscription(int id, [FromBody] CourseSubscriptionModel subscription)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return BadRequest if model state is invalid
                }

                var updatedLearner = await _service.UpdateCourseSubscription(id, subscription);
                if (updatedLearner == null)
                {
                    return NotFound(); // Return NotFound if the learner does not exist
                }

                return Ok(updatedLearner); // Return the updated learner
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
