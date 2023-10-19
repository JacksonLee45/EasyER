using EasyER.Server.Controllers;
using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


namespace EasyERTests
{
    public class DoctorControllerTests
    {
        private Mock<IDoctorRepository> mockRepo;
        private DoctorController doctorController;
        private List<Doctor> doctors;
        private Doctor doctorWithId = new Doctor().WithFirstName("Greta").WithId(2).WithEmail("doctor@gmail.com");



        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IDoctorRepository>();
            doctorController = new DoctorController(mockRepo.Object);
            doctors = new List<Doctor>();
            doctors.Add(new Doctor().WithFirstName("Bob"));
            doctors.Add(new Doctor().WithFirstName("Dave"));
        }

        [Test]
        public void PostNewDoctor_callsSavesNewDoctor_returnsDoctorWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.SaveDoctor(doctors[0])).Returns(doctorWithId);
            //Act
            Doctor actual = doctorController.PostNewDoctor(doctors[0]);
            //Assert
            mockRepo.Verify(repo => repo.SaveDoctor(doctors[0]), Times.Once());
            Assert.That(actual, Is.EqualTo(doctorWithId));
        }

        [Test]
        public void PutDoctor_callsUpdateInRepo_ReturnsDoctor()
        {
            //Arrange
            mockRepo.Setup(r => r.UpdateDoctor(doctorWithId)).Returns(doctorWithId);
            //ACT
            Doctor doctorUpdated = doctorController.PutDoctor(doctorWithId);
            //Assert
            mockRepo.Verify(repo => repo.UpdateDoctor(doctorWithId), Times.Once());
            Assert.That(doctorUpdated, Is.EqualTo(doctorWithId));
        }

        
        [Test]
        public void GetDoctorId_GetsDoctorWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.GetLoggedInDoctor("doctor@gmail.com")).Returns(doctorWithId);

            //Act
            Doctor actual = doctorController.GetDoctorId("doctor@gmail.com");

            //Assert
            mockRepo.Verify(repo => repo.GetLoggedInDoctor("doctor@gmail.com"), Times.Once());
            Assert.That(actual, Is.EqualTo(doctorWithId));
        }
    }
}
