using EasyER.Server.Controllers;
using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


namespace EasyERTests
{
    public class NurseControllerTests
    {
        private Mock<INurseRepository> mockRepo;
        private NurseController nurseController;
        private List<Nurse> nurses;
        private Nurse nurseWithId = new Nurse().WithFirstName("Greta").WithId(2).WithEmail("nurse@gmail.com");


        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<INurseRepository>();
            nurseController = new NurseController(mockRepo.Object);
            nurses = new List<Nurse>();
            nurses.Add(new Nurse().WithFirstName("Bob"));
            nurses.Add(new Nurse().WithFirstName("Dave"));
        }

        [Test]
        public void PostNewNurse_callsSavesNewNurse_returnsNurseWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.SaveNurse(nurses[0])).Returns(nurseWithId);

            //Act
            Nurse actual = nurseController.PostNewNurse(nurses[0]);

            //Assert
            mockRepo.Verify(repo => repo.SaveNurse(nurses[0]), Times.Once());
            Assert.That(actual, Is.EqualTo(nurseWithId));
        }

        [Test]
        public void GetNurseId_GetsNurseWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.GetLoggedInNurse("nurse@gmail.com")).Returns(nurseWithId);

            //Act
            Nurse actual = nurseController.GetNurseId("nurse@gmail.com");

            //Assert
            mockRepo.Verify(repo => repo.GetLoggedInNurse("nurse@gmail.com"), Times.Once());
            Assert.That(actual, Is.EqualTo(nurseWithId));
        }
    }
}
