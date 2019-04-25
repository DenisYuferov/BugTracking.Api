using AutoMapper;
using Xunit;
using Moq;
using BugTracking.Api.Infrastructure.Repository;
using BugTracking.Api.Infrastructure.Services;
using BugTracking.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Tests.Services
{
    public class ProjectServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ProjectRepository> _mockProjectRepository;

        public ProjectServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _mockProjectRepository = new Mock<ProjectRepository>();
        }

        //[Fact]
        public async void GetProjectAsyncTest()
        {
            // Arrange
            var project = new Models.Project();
            var projectResponse = new ProjectResponse();

            // Act
            _mockProjectRepository.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);
            _mapperMock.Setup(m => m.Map<ProjectResponse>(It.IsAny<Models.Project>())).Returns(projectResponse);

            var projectService = new ProjectService(_mapperMock.Object, _mockProjectRepository.Object);

            var result = await projectService.GetProjectAsync(It.IsAny<int>());

            // Assert
            Assert.True(result.Value != null);
        }

        //[Fact]
        public async void GetProjectNotFoundAsyncTest()
        {
            // Arrange
            Models.Project project = null;

            // Act
            _mockProjectRepository.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

            var projectService = new ProjectService(_mapperMock.Object, _mockProjectRepository.Object);

            var result = await projectService.GetProjectAsync(It.IsAny<int>());
            // Assert
            Assert.True(result.Result is NotFoundObjectResult);
        }
    }
}
