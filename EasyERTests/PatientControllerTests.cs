using EasyER.Server.Controllers;
using EasyER.Server.Models;
using EasyER.Server.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EasyERTests
{
    public class PatientControllerTests
    {
        private Mock<IPatientRepository> mockRepo;
        private PatientController patientController;
        private List<Patient> patients;
        private Patient patientWithId = (Patient)new Patient().WithFirstName("Peter").WithIsActive(true).WithId(1);

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IPatientRepository>();
            patientController = new PatientController(mockRepo.Object);
            patients = new List<Patient>();
            patients.Add(new Patient().WithFirstName("Bob").WithIsActive(true).WithTraumaLevel(3));
            patients.Add(new Patient().WithFirstName("Dave").WithIsActive(true).WithTraumaLevel(2));
        }

        [Test]
        public void GetAllActivePatients_ReturnsActivePatients()
        {
            //Arrange
            mockRepo.Setup(r => r.GetActivePatients()).Returns(patients);

            //Act
            List<Patient> actual = patientController.GetAllActivePatients();

            //Assert
            mockRepo.Verify(repo => repo.GetActivePatients(), Times.Once());
            Assert.That(actual, Is.EqualTo(patients));
        }

        [Test]
        public void GetPatientById_ReturnsPatientWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.GetPatientById(1)).Returns(patientWithId);

            //Act
            Patient actual = patientController.GetPatientById(1);

            //Assert
            mockRepo.Verify(repo => repo.GetPatientById(1), Times.Once());
            Assert.That(actual, Is.EqualTo(patientWithId));
        }

        [Test]
        public void DeactivatePatient_DeactivatesPatientWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.DeactivatePatient(1)).Returns(true);

            //Act
            bool actual = patientController.DeactivatePatient(1);

            //Assert
            mockRepo.Verify(repo => repo.DeactivatePatient(1), Times.Once());
            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void GetPatientQueue_ReturnsPatientQueue()
        {
            //Arrange
            mockRepo.Setup(r => r.GetPatientQueue()).Returns(patients);

            //Act
            List<Patient> actual = patientController.GetPatientQueue();

            //Assert
            mockRepo.Verify(repo => repo.GetPatientQueue(), Times.Once());
            Assert.That(actual, Is.EqualTo(patients));
        }


        [Test]
        public void PostNewPatient_callsSavesNewPatient_returnsPatientWithId()
        {
            //Arrange
            mockRepo.Setup(r => r.SavePatient(patients[0])).Returns(patientWithId);
            //Act
            Patient actual = patientController.PostNewPatient(patients[0]);
            //Assert
            mockRepo.Verify(repo => repo.SavePatient(patients[0]), Times.Once());
            Assert.That(actual, Is.EqualTo(patientWithId));
        }

        [Test]
        public void PutPatient_callsUpdateInRepo_ReturnsPatient()
        {
            //Arrange
            mockRepo.Setup(r => r.UpdatePatient(patientWithId)).Returns(patientWithId);

            //ACT
            Patient patientUpdated = patientController.PutPatient(patientWithId);

            //Assert
            mockRepo.Verify(repo => repo.UpdatePatient(patientWithId), Times.Once());
            Assert.That(patientUpdated, Is.EqualTo(patientWithId));
        }
    }
}