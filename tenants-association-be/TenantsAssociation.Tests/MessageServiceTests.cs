using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.Tests
{
    [TestClass]
    public class MessageServiceTests
    {
        private IMessageService _messageService;
        private readonly Mock<IMessageRepository> _messageRepository = new Mock<IMessageRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public MessageServiceTests()
        {
            _unitOfWork.Setup(uow => uow.Messages).Returns(_messageRepository.Object);
            _messageService = new MessageService(_unitOfWork.Object);
        }

        [TestMethod]
        public async Task AddMessage_ShouldAddMessage()
        {
            // Arrange
            var messageDto = new MessageDto { Description = "Your rent is due." };
            var userId = 1;
            _messageRepository.Setup(mr => mr.InsertAsync(It.IsAny<Message>())).Verifiable();

            // Act
            await _messageService.AddMessage(messageDto, userId);

            // Assert
            _messageRepository.Verify(mr => mr.InsertAsync(It.IsAny<Message>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddMessage_ShouldSaveChanges()
        {
            // Arrange
            var messageDto = new MessageDto { Description = "Test message" };
            var userId = 1;
            _messageRepository.Setup(mr => mr.InsertAsync(It.IsAny<Message>())).Returns(Task.CompletedTask).Verifiable();

            // Act
            _messageService.AddMessage(messageDto, userId).Wait();

            // Assert
            _messageRepository.Verify(mr => mr.InsertAsync(It.Is<Message>(m => m.UserId == userId && m.Description == messageDto.Description)), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }
    }
}
