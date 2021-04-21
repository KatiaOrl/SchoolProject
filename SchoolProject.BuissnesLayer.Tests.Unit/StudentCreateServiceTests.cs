using System;
using System.Threading.Tasks;
using AutoFixture;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.BuissnesLayer.Interfaces;
using SchoolProject.BuissnesLayer.Implementation;
using SchoolProject.Domain;
using SchoolProject.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;


namespace SchoolProject.BuissnesLayer.Tests.Unit
{
    public class StudentCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_ClassNumbValidationSucceed_CreatesStudent()
        {
            // Arrange
            var student = new StudentsUpdateModel();
            var expected = new Student();

            var classNumbGetService = new Mock<IClassNumbGetService>();
            classNumbGetService.Setup(x => x.ValidateAsync(student));

            var studentDataAccess = new Mock<IStudentsRepository>();
            studentDataAccess.Setup(x => x.InsertAsync(student)).ReturnsAsync(expected);

            var studentGetService = new StudentCreateService(studentDataAccess.Object, classNumbGetService.Object);

            // Act
            var result = await studentGetService.CreateAsync(student);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_ClassNumbValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var student = new StudentsUpdateModel();
            var expected = fixture.Create<string>();

            var classNumbGetService = new Mock<IClassNumbGetService>();
            classNumbGetService
                .Setup(x => x.ValidateAsync(student))
                .Throws(new InvalidOperationException(expected));

            var studentDataAccess = new Mock<IStudentsRepository>();

            var studentCreateService = new StudentCreateService(studentDataAccess.Object, classNumbGetService.Object);

            // Act
            var action = new Func<Task>(() => studentCreateService.CreateAsync(student));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            studentDataAccess.Verify(x => x.InsertAsync(student), Times.Never);
        }
    }
}
