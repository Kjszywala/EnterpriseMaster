using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.DesktopApp.Data.Services.HumanResourcesServices
{
    public class HrService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IJobOffersServices jobOffersServices;
        private readonly ITrainingsServices trainingsServices;

        #endregion

        #region Constructor

        public HrService(IErrorLogsServices _errorLogsServices, IJobOffersServices _jobOffersServices, ITrainingsServices _trainingsServices)
        {
            errorLogsServices = _errorLogsServices;
            jobOffersServices = _jobOffersServices;
            trainingsServices = _trainingsServices;
        }

        #endregion

        #region Methods

        #region Recruitment

        public async Task<List<JobOffers>> GetAllJobOffersAsync()
        {
            try
            {
                return (await jobOffersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<JobOffers> GetJobOfferAsync(int id)
        {
            try
            {
                return (await jobOffersServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddJobOfferAsync(JobOffers jobOffer)
        {
            try
            {
                jobOffer.Company = Config.CompanyId;
                return (await jobOffersServices.AddAsync(jobOffer));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateJobOfferAsync(JobOffers jobOffer)
        {
            try
            {
                return (await jobOffersServices.EditAsync(jobOffer.Id, jobOffer));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveJobOfferAsync(int id)
        {
            try
            {
                return (await jobOffersServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Trainings

        public async Task<List<Trainings>> GetAllTrainingsAsync()
        {
            try
            {
                return (await trainingsServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Trainings> GetTrainingAsync(int id)
        {
            try
            {
                return (await trainingsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddTrainingAsync(Trainings training)
        {
            try
            {
                training.Company = Config.CompanyId;
                return (await trainingsServices.AddAsync(training));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateTrainingAsync(Trainings training)
        {
            try
            {
                return (await trainingsServices.EditAsync(training.Id, training));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveTrainingAsync(int id)
        {
            try
            {
                return (await trainingsServices.RemoveAsync(id));
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
