using System.Collections.Generic;
using System.Threading.Tasks;
using Hilton.HotelManagement.AppServices.HotelOperations.Reservations.Dtos;
using Hilton.HotelManagement.HotelOperations;
using Hilton.HotelManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hilton.HotelManagement.AppServices.HotelOperations.Reservations
{
    [Authorize(HotelManagementPermissions.Pages_Reservations_Get)]
    public class ReservationAppService : ApplicationService, IReservationAppService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationAppService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public virtual async Task<PagedResultDto<ReservationDto>> GetListAsync(GetReservationsInput input)
        {
            var totalCount = await _reservationRepository.GetCountAsync(input.FilterText, input.ReservationFilter);

            var reservations = await _reservationRepository
                .GetListAsync(
                    input.FilterText,
                    input.ReservationFilter,
                    input.Sorting,
                    input.MaxResultCount,
                    input.SkipCount
                );

            return new PagedResultDto<ReservationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Reservation>, List<ReservationDto>>(reservations)
            };
        }

        public virtual async Task<ReservationDto> GetAsync(long id)
        {
            return ObjectMapper.Map<Reservation, ReservationDto>(
                await _reservationRepository.GetAsync(id));
        }

        [Authorize(HotelManagementPermissions.Pages_Reservations_Delete)]
        public virtual async Task DeleteAsync(long id)
        {
            await _reservationRepository.DeleteAsync(id);
        }

        [Authorize(HotelManagementPermissions.Pages_Reservations_Create)]
        public virtual async Task<ReservationDto> CreateAsync(ReservationCreateDto input)
        {
            var newReservation = ObjectMapper.Map<ReservationCreateDto, Reservation>(input);

            //todo: only for IMultiTenant entities.
            newReservation.TenantId = CurrentTenant.Id;

            var reservation = await _reservationRepository.InsertAsync(newReservation);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Reservation, ReservationDto>(reservation);
        }

        [Authorize(HotelManagementPermissions.Pages_Reservations_Update)]
        public virtual async Task UpdateAsync(ReservationUpdateDto input)
        {
            var reservation = await _reservationRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, reservation);
        }
    }
}