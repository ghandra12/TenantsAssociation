using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.Tests
{
    [TestClass]
    public class InvoiceServiceTests
    {
        private IInvoiceService invoiceService;
        private readonly Mock<IInvoiceRepository> _invoiceRepository = new Mock<IInvoiceRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public InvoiceServiceTests()
        {
            _unitOfWork.Setup(uow => uow.Invoices).Returns(_invoiceRepository.Object);
            invoiceService = new InvoiceService(_unitOfWork.Object);
        }

        [TestMethod]
        public void UpdateInvoiceStatus_InvoiceNotFound()
        {
            //Arrange
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns<Invoice?>(null);
            //Act
            invoiceService.UpdateInvoiceStatus(1);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Never);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void UpdateInvoiceStatus_InvoiceFound_ShouldUpdate()
        {
            //Arrange
            var invoice = new Invoice()
            {
                Description = "TEST",
                DueDate = DateTime.Now,
                Id = 1,
                InvoiceNumber = 1,
                Sum = 500,
                UserId = 1,
                ReleaseDate = DateTime.Now
            };
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns(invoice);
            //Act
            invoiceService.UpdateInvoiceStatus(1);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddInvoice_ShouldAddInvoice()
        {
            //Arrange
            _invoiceRepository.Setup(ir => ir.InsertAsync(It.IsAny<Invoice>())).Verifiable();
            //Act
            invoiceService.AddInvoice(new InvoiceDto() { Id = 1 });
            //Assert
            _invoiceRepository.Verify(ir => ir.InsertAsync(It.IsAny<Invoice>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetUnpaidInvoices_ShouldReturnUnpaidInvoices()
        {
            //Arrange
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                },
                new Invoice
                {
                    Id = 2,
                }
            };
            _invoiceRepository.Setup(ir => ir.GetUnpaidInvoicesByUserId(It.IsAny<int>())).Returns(invoices);
            //Act
            var result = invoiceService.GetUnpaidInvoices(1);
            //Assert
            Assert.AreEqual(result.Count, 2);
        }
    }
}
