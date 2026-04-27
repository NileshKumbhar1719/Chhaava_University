using NUnit.Framework;
using Moq;
using Exam.Models;
using Exams.Repository;
using Exams.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exams.NUnitTest
{
    public class ExamServiceTest
    {
        private Mock<IExamRepository> _mockRepo;
        private ExamService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IExamRepository>();
            _service = new ExamService(_mockRepo.Object);
        }

        [Test]
        public async Task GetExamsAsync_ReturnsList()
        {
            var exams = new List<Exampaper>
            {
                new Exampaper { Id = 1, Name = "Math" },
                new Exampaper { Id = 2, Name = "Science" }
            };

            _mockRepo.Setup(r => r.GetAllExamsAsync())
                     .ReturnsAsync(exams);

            var result = await _service.GetExamsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task GetExambyIdAsync_ReturnsExam()
        {
            var exam = new Exampaper { Id = 1, Name = "Math" };

            _mockRepo.Setup(r => r.GetByIdAsync(1))
                     .ReturnsAsync(exam);

            var result = await _service.GetExambyIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task CreateExame_Valid_ReturnsCreatedExam()
        {
            var exam = new Exampaper { Id = 1, Name = "Math" };

            _mockRepo.Setup(r => r.CreateAsync(exam))
                     .ReturnsAsync(exam);

            var result = await _service.CreateExame(exam);

            Assert.IsNotNull(result);
            Assert.AreEqual("Math", result.Name);
        }

        [Test]
        public void CreateExame_Null_ThrowsArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _service.CreateExame(null);
            });
        }

        [Test]
        public async Task UpdateExame_ReturnsUpdated()
        {
            var exam = new Exampaper { Id = 1, Name = "Updated" };

            _mockRepo.Setup(r => r.UpdateAsync(exam, 1))
                     .ReturnsAsync(exam);

            var result = await _service.UpdateExame(exam, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated", result.Name);
        }

        [Test]
        public async Task DeleteExamAsync_ReturnsDeletedExam()
        {
            var exam = new Exampaper { Id = 1, Name = "Math" };

            _mockRepo.Setup(r => r.DeleteAsync(1))
                     .ReturnsAsync(true);

            var result = await _service.DeleteExamAsync(1);

            Assert.IsNotNull(result);
        }
    }
}