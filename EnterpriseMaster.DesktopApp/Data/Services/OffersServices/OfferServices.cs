using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.OffersServices
{
    public class OfferServices
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IProductsServices productsServices;
        private readonly IOfferServices offerServices;
        private readonly ICustomerInformationsServices customerInformationsServices;

        #endregion

        #region Constructor

        public OfferServices(
            IErrorLogsServices _errorLogsServices, 
            IProductsServices _productsServices, 
            IOfferServices _offerServices, 
            ICustomerInformationsServices _customerInformationsServices)
        {
            errorLogsServices = _errorLogsServices;
            productsServices = _productsServices;
            offerServices = _offerServices;
            customerInformationsServices = _customerInformationsServices;
        }

        #endregion

        #region Methods

        #region Offers

        public async Task<List<Offers>> GetAllOffersAsync()
        {
            try
            {
                return (await offerServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Offers> GetOffersAsync(int id)
        {
            try
            {
                return (await offerServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddOffersAsync(Offers offers)
        {
            try
            {
                return (await offerServices.AddAsync(offers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateOffersAsync(Offers offers)
        {
            try
            {
                return (await offerServices.EditAsync(offers.Id, offers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveOffersAsync(int id)
        {
            try
            {
                return (await offerServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Products

        public async Task<List<Products>> GetAllProductsAsync()
        {
            try
            {
                var products = (await productsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return (await productsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Products> GetProductAsync(int id)
        {
            try
            {
                return (await productsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddProductAsync(Products product)
        {
            try
            {
                return (await productsServices.AddAsync(product));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateProductAsync(Products product)
        {
            try
            {
                return (await productsServices.EditAsync(product.Id, product));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                return (await productsServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #endregion
    }
}
