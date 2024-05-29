using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;
using TenantsAssociation.DataAccess.Repository;

namespace TenantsAssociation.Tests
{
    [TestClass]
    public class InvoiceServiceTests
    {
        private IInvoiceService invoiceService;
        private readonly Mock<IInvoiceRepository> _invoiceRepository = new Mock<IInvoiceRepository>();
        private readonly Mock<IPaymentRepository> _paymentRepository = new Mock<IPaymentRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public InvoiceServiceTests()
        {
            _unitOfWork.Setup(uow => uow.Invoices).Returns(_invoiceRepository.Object);
            _unitOfWork.Setup(uow => uow.Payments).Returns(_paymentRepository.Object);
            invoiceService = new InvoiceService(_unitOfWork.Object);
        }

        [TestMethod]
        public void AddPayment_InvoiceNotFoundShouldThrowException()
        {
            //Arrange
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns<Invoice?>(null);
            //Act
            invoiceService.AddPayment(1, 1);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Never);
            _paymentRepository.Verify(ir => ir.InsertAsync(It.IsAny<Payment>()), Times.Never);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void AddPayment_InvoiceAlreadyPaidShouldThrowException()
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
                ReleaseDate = DateTime.Now,
                IsPaid = true,
            };
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns(invoice);
            //Act
            invoiceService.AddPayment(1, 1);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Never);
            _paymentRepository.Verify(ir => ir.InsertAsync(It.IsAny<Payment>()), Times.Never);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void AddPayment_PayingMoreThanRemainingShouldThrowException()
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
                ReleaseDate = DateTime.Now,
                IsPaid = false,
            };

            var payments = new List<Payment>()
            {
                new Payment()
                {
                    Id = 1,
                    InvoiceId = 1,
                    Sum = 450
                }
            };
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns(invoice);
            _paymentRepository.Setup(pr => pr.GetPaymentsByInvoiceId(It.IsAny<int>())).Returns(payments);
            //Act
            invoiceService.AddPayment(1, 60);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Never);
            _paymentRepository.Verify(ir => ir.InsertAsync(It.IsAny<Payment>()), Times.Never);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void AddPayment_PartialPaymentShouldInsertWithoutModifyingInvoiceStatus()
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
                ReleaseDate = DateTime.Now,
                IsPaid = false,
            };

            var payments = new List<Payment>()
            {
                new Payment()
                {
                    Id = 1,
                    InvoiceId = 1,
                    Sum = 400
                }
            };
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns(invoice);
            _paymentRepository.Setup(pr => pr.GetPaymentsByInvoiceId(It.IsAny<int>())).Returns(payments);
            //Act
            invoiceService.AddPayment(1, 60);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Never);
            _paymentRepository.Verify(ir => ir.InsertAsync(It.IsAny<Payment>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddPayment_CompletePaymentShouldInsertAndModifyInvoiceStatus()
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
                ReleaseDate = DateTime.Now,
                IsPaid = false,
            };

            var payments = new List<Payment>()
            {
                new Payment()
                {
                    Id = 1,
                    InvoiceId = 1,
                    Sum = 440
                }
            };
            _invoiceRepository.Setup(ir => ir.GetInvoiceById(It.IsAny<int>())).Returns(invoice);
            _paymentRepository.Setup(pr => pr.GetPaymentsByInvoiceId(It.IsAny<int>())).Returns(payments);
            //Act
            invoiceService.AddPayment(1, 60);
            //Assert
            _invoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()), Times.Once);
            _paymentRepository.Verify(ir => ir.InsertAsync(It.IsAny<Payment>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Exactly(2));
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
