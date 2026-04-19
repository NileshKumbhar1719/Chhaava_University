using NUnit.Framework;
using Moq;
using Chhaava_University.Models;
using Chhaava_University.Repository;
using Chhaava_University.Service;


namespace Chhaava_University.Testing
{
    public class Test
    {
        private Mock<IUniversityRepository> _mockRepo;
        private UniversityService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IUniversityRepository>();
            _service = new UniversityService(_mockRepo.Object);
        }

        [Test]
        public async Task GetAllAsync_ReturnsListOfUniversities()
        {
            var universities = new List<University>
            {
                new University { Id = 1, Name = "Uni1" },
                new University { Id = 2, Name = "Uni2" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync())
                     .ReturnsAsync(universities);

            var result = await _service.GetAllAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsUniversity()
        {
            var university = new University { Id = 1, Name = "Uni1" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1))
                     .ReturnsAsync(university);

            var result = await _service.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task CreateAsync_ValidUniversity_ReturnsCreatedUniversity()
        {
            var university = new University { Id = 1, Name = "Uni1" };

            _mockRepo.Setup(repo => repo.CreateUniversityAsync(university))
                     .ReturnsAsync(university);

            var result = await _service.CreateAsync(university);

            Assert.IsNotNull(result);
            Assert.AreEqual("Uni1", result.Name);
        }

        [Test]
        public void CreateAsync_NullUniversity_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _service.CreateAsync(null));
        }

        [Test]
        public async Task UpdateAsync_ReturnsUpdatedUniversity()
        {
            var university = new University { Id = 1, Name = "Updated" };

            _mockRepo.Setup(repo => repo.UpdateUniversityAsync(university))
                     .ReturnsAsync(university);

            var result = await _service.UpdateAsync(university);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated", result.Name);
        }

        [Test]
        public async Task DeleteAsync_ReturnsTrue_WhenDeleted()
        {
            _mockRepo.Setup(repo => repo.DeleteUniversityAsync(1))
                     .ReturnsAsync(true);

            var result = await _service.DeleteAsync(1);

            Assert.IsTrue(result);
        }
    }
}