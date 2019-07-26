using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_Repo_Pattern.Interfaces;

namespace Task_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private IRepositoryFactory _repository;
        private ILogManager _logger;
        public TasksController(IRepositoryFactory repository, ILogManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _repository.Task.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured: {ex.Message}");
                return new BadRequestObjectResult(ExceptionHelper.ErrorDetails(ex));
            }
        }

        [HttpGet("{id}",Name ="TaskById")]
        public async Task<IActionResult> Get(int id,[FromHeader] string accept)
        {
            try
            {
                var task = await _repository.Task.GetTaskByIdAsync(id);

                if (task.Id.Equals(default))
                {
                    _logger.LogError($"task id: {id}, not found.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"found task with id: {id}");
                    if (accept.EndsWith("hal"))
                    {
                        var link = new LinkHelper<Model.Task>(task);
                        link.Links.Add(new Link
                        {
                            Href = Url.Link("TaskById", new { task.Id }),
                            Rel = "self",
                            method = "GET"
                        });
                        //not implemented at repo level
                        //link.Links.Add(new Link
                        //{
                        //    Href = Url.Link("Puttask", new { task.Id }),
                        //    Rel = "put-task",
                        //    method = "PUT"
                        //});
                        link.Links.Add(new Link
                        {
                            Href = Url.Link("DeleteTask", new { task.Id }),
                            Rel = "delete-task",
                            method = "DELETE"
                        });
                        return new ObjectResult(link);
                    }
                    return Ok(task);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured: {ex.Message}");
                return new BadRequestObjectResult(ExceptionHelper.ErrorDetails(ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Model.Task task)
        {
            try
            {
                if (task == null)
                {
                    _logger.LogError("task is null.");
                    return BadRequest("task is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model task.");
                    return BadRequest("Invalid model object");
                }

                await _repository.Task.CreateTaskAsync(task);

                return CreatedAtRoute("TaskById", new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured: {ex.Message}");
                return new BadRequestObjectResult(ExceptionHelper.ErrorDetails(ex));
            }
        }

       
        [HttpDelete("{id}",Name = "DeleteTask")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var task = await _repository.Task.GetTaskByIdAsync(id);

                if (task.Id.Equals(default))
                {
                    _logger.LogError($"task id: {id}, not found.");
                    return NotFound();
                }
                await _repository.Task.DeletetaskAsync(task);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured: {ex.Message}");
                return new BadRequestObjectResult(ExceptionHelper.ErrorDetails(ex));
            }
        }
    }
}
