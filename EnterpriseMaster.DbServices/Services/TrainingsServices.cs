using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class TrainingsServices :
        BaseServices<Trainings>,
        ITrainingsServices
    {
        public TrainingsServices()
            : base("/api/v1.0/Trainings/")
        {
        }
    }
}
