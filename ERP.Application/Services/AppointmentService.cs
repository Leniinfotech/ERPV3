using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Appointment>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Appointment?> GetByIdAsync(string fran, decimal appointId) =>
            _repository.GetByIdAsync(fran, appointId);

        public Task AddAsync(Appointment entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(Appointment entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, decimal appointId) => _repository.DeleteAsync(fran, appointId);
    }
}

