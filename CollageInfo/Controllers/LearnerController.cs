using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollageInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly ILearnerService _learnerService;
        public LearnerController(ILearnerService learnerService)
        {
            _learnerService = learnerService;
        }

        [HttpPost]
        [Route("AddLearner")]
        public async Task<IActionResult> AddLearner([FromBody] List<LearnerModel> learnerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _learnerService.AddLearnerAsync(learnerModel);

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
        [HttpGet]
        [Route("GetAllLearners")]
        public async Task<ActionResult<List<Learner>>> GetAllLearners()
        {
            try
            {
                var learners = await _learnerService.GetAllLearners();
                return Ok(learners); // Return the list of learners
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("GetLearnerById{id}")]
        public async Task<ActionResult<Learner>> GetLearnerById(int id)
        {
            try
            {
                var learner = await _learnerService.GetLearnerById(id);

                if (learner == null)
                {
                    return NotFound($"Learner with ID {id} not found.");
                }

                return Ok(learner); // Return the learner data
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut()]
        [Route("UpdateLearnerById{id}")]
        public async Task<IActionResult> UpdateLearnerById(int id, [FromBody] LearnerModel learnerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return BadRequest if model state is invalid
                }

                var updatedLearner = await _learnerService.UpdateLearnerById(id, learnerModel);
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

        [HttpDelete()]
        [Route("DeleteLearnerById{id}")]
        public async Task<IActionResult> DeleteLearnerById(int id)
        {
            try
            {
                var result = await _learnerService.DeleteLearnerById(id);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Data not found"); // Return NotFound if the learner does not exist
                }

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
