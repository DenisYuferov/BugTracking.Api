using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTracking.Api.Infrastructure.Repository;
using BugTracking.Api.Infrastructure.Services.Interfaces;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.Api.Infrastructure.Services
{
    /// <summary> Task service </summary>
    public class TaskService : ITaskService
    {
        private readonly ProjectRepository _projectRepository;
        private readonly TaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper,
                           ProjectRepository projectRepository,
                           TaskRepository taskRepository
                          )
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }

        /// <summary> Get tasks </summary>
        public async Task<ActionResult<List<TaskResponse>>> GetTasksAsync(TasksRequest tasksRequest)
        {
            var tasks = _taskRepository.All();

            TryFilterTasks(ref tasks, tasksRequest);
            TrySortTasks(ref tasks, tasksRequest);

            var tasksList = await tasks.ToListAsync();

            var tasksResponseList = _mapper.Map<List<TaskResponse>>(tasksList);

            return tasksResponseList;
        }

        /// <summary> Get task </summary>
        public async Task<ActionResult<TaskResponse>> GetTaskAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null) return new NotFoundObjectResult($"Task is not found with id:{id}");

            var taskResponse = _mapper.Map<TaskResponse>(task);

            return taskResponse;
        }

        /// <summary> Add task </summary>
        public async Task<ActionResult> AddTaskAsync(TaskAddRequest addTaskRequest)
        {
            var project = await _projectRepository.GetByIdAsync(addTaskRequest.ProjectId);

            if (project == null) return new NotFoundObjectResult($"Project is not found with id:{addTaskRequest.ProjectId}");

            var task = _mapper.Map<Models.Task>(addTaskRequest);
            task.StatusId = 1;

            await _taskRepository.InsertAsync(task);

            return new OkResult();
        }

        /// <summary> Change task </summary>
        public async Task<ActionResult> ChangeTaskAsync(int id, TaskChangeRequest taskChangeRequest)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null) return new NotFoundObjectResult($"Task is not found with id:{id}");

            bool? isAllowedStatus = null;

            if (task.StatusId == 1)
            {
                isAllowedStatus = taskChangeRequest.StatusId == 2 || taskChangeRequest.StatusId == 3;
            }
            else if (task.StatusId == 2)
            {
                isAllowedStatus = taskChangeRequest.StatusId == 1 || taskChangeRequest.StatusId == 3;
            }
            else if (task.StatusId == 3)
            {
                return new UnprocessableEntityObjectResult("Task changing is not allowed");
            }

            if (isAllowedStatus == null) return new NotFoundObjectResult($"Status is not found with id:{id}");
            if (isAllowedStatus == false) return new UnprocessableEntityObjectResult($"Status is not allowed with id:{id}");

            task.Name = taskChangeRequest.Name;
            task.Description = taskChangeRequest.Description;
            task.StatusId = taskChangeRequest.StatusId;
            
            await _taskRepository.UpdateAsync(task);

            return new OkResult();
        }

        /// <summary> Delete task </summary>
        public async Task<ActionResult> DeleteTaskAsync(int id)
        {
            var result = await _taskRepository.DeleteByIdAsync(id);

            if (!result) return new NotFoundObjectResult($"Task is not found with id:{id}");

            return new OkResult();
        }

        private void TryFilterTasks(ref IQueryable<Models.Task> tasks, TasksRequest tasksRequest)
        {
            if (tasksRequest.FilterByCreationDateStart != null)
            {
                tasks = tasks.Where(t => t.CreationDate >= tasksRequest.FilterByCreationDateStart);
            }

            if (tasksRequest.FilterByCreationDateEnd != null)
            {
                tasks = tasks.Where(t => t.CreationDate <= tasksRequest.FilterByCreationDateEnd);
            }

            if (tasksRequest.FilterByModificationDateStart != null)
            {
                tasks = tasks.Where(t => t.ModificationDate >= tasksRequest.FilterByModificationDateStart);
            }

            if (tasksRequest.FilterByModificationDateEnd != null)
            {
                tasks = tasks.Where(t => t.ModificationDate <= tasksRequest.FilterByModificationDateEnd);
            }

            if (tasksRequest.FilterByPriority != null)
            {
                tasks = tasks.Where(t => t.Priority == tasksRequest.FilterByPriority);
            }

            if (tasksRequest.FilterByStatusId != null)
            {
                tasks = tasks.Where(t => t.StatusId == tasksRequest.FilterByStatusId);
            }
        }

        private void TrySortTasks(ref IQueryable<Models.Task> tasks, TasksRequest tasksRequest)
        {
            if (tasksRequest.SortByCreationDateAsc != null)
            {
                tasks = tasksRequest.SortByCreationDateAsc == true ? 
                    tasks.OrderBy(t => t.CreationDate) : tasks.OrderByDescending(t => t.CreationDate);
            }

            if (tasksRequest.SortByModificationDateAsc != null)
            {
                tasks = tasksRequest.SortByModificationDateAsc == true ?
                    tasks.OrderBy(t => t.ModificationDate) : tasks.OrderByDescending(t => t.ModificationDate);
            }

            if (tasksRequest.SortByPriorityAsc != null)
            {
                tasks = tasksRequest.SortByPriorityAsc == true ?
                    tasks.OrderBy(t => t.Priority) : tasks.OrderByDescending(t => t.Priority);
            }
        }
    }
}
