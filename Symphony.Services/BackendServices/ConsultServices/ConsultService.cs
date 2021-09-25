using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.ConsultServices
{
    public class ConsultService : IConsultService
    {
        private readonly SymphonyDBContext _context;

        public ConsultService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task DeleteConsultRegistration(int id)
        {
            var _regis = await _context.ConsultRegistrations.FirstOrDefaultAsync(x => x.Id == id);
            if (_regis != null)
            {
                _context.ConsultRegistrations.Remove(_regis);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ConsultVM> GetConsultRegistration(int id)
        {
            var _regis = await _context.ConsultRegistrations
                        .SingleOrDefaultAsync(x => x.Id == id);
            return _regis.AsConsultVM();
        }

        public async Task<IEnumerable<ConsultVM>> GetConsultRegistrations()
        {
            var regis = await _context.ConsultRegistrations
                        .Select(x => x.AsConsultVM())
                        .ToListAsync();
            return regis;
        }

        public async Task<int> PostConsultRegistration(ConsultCreateRequest registration)
        {
            var regis = new ConsultRegistration()
            {
                UserId = registration.UserId,
                FullName = registration.FullName,
                Phone = registration.Phone,
                Email = registration.Email,
                CreatedAt = DateTime.Now,
                Message = registration.Message,
                IsContacted = false
            };

            await _context.AddAsync(regis);
            await _context.SaveChangesAsync();

            return regis.Id;
        }

        public async Task PutConsultRegistration(ConsultUpdateRequest registration, int id)
        {
            var _regis = await _context.ConsultRegistrations
                        .SingleOrDefaultAsync(x => x.Id == id);

            _regis.IsContacted = registration.IsContacted;
            await _context.SaveChangesAsync();
        }
    }
}