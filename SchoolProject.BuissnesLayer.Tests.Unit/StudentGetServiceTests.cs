using System;
using System.Threading.Tasks;
using AutoFixture;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.BuissnesLayer.Implementation;
using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SchoolProject.BuissnesLayer.Tests.Unit
{
    [TestFixture]
    public class StudentGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_StudentExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<IStudentIdentity>();

            var student = new Student();
            var studentDataAccess = new Mock<IStudentsRepository>();
            studentDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(student);

            var studentGetService = new StudentGetService(studentDataAccess.Object);

            // Act
            var action = new Func<Task>(() => studentGetService.ValidateAsync(departmentContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_StudentNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var studentContainer = new Mock<IStudentIdentity>();
            studentContainer.Setup(x => x.Id).Returns(id);

            var department = new Student();
            var departmentDataAccess = new Mock<IStudentsRepository>();
            departmentDataAccess.Setup(x => x.GetByAsync(studentContainer.Object)).ReturnsAsync((Student)null);

            var departmentGetService = new StudentGetService(departmentDataAccess.Object);

            // Act
            var action = new Func<Task>(() => departmentGetService.ValidateAsync(studentContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Student not found by id {id}");
        }
    }
}