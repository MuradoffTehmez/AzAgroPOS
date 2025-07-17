using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class NovbeIdaretmesiService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public NovbeIdaretmesiService(IUnitOfWork unitOfWork, IAuditLogService auditLogService = null)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService;
        }

        #region Schedule Management

        public async Task<IEnumerable<NovbeCedveli>> GetAllSchedulesAsync()
        {
            return await _unitOfWork.NovbeCedvelleri.GetAllAsync();
        }

        public async Task<NovbeCedveli> GetScheduleByIdAsync(int id)
        {
            return await _unitOfWork.NovbeCedvelleri.GetByIdAsync(id);
        }

        public async Task<IEnumerable<NovbeCedveli>> GetActiveSchedulesAsync()
        {
            return await _unitOfWork.NovbeCedvelleri.GetActiveSchedulesAsync();
        }

        public async Task<NovbeCedveli> CreateScheduleAsync(NovbeCedveli schedule)
        {
            return await _unitOfWork.NovbeCedvelleri.AddAsync(schedule);
        }

        public async Task<NovbeCedveli> UpdateScheduleAsync(NovbeCedveli schedule)
        {
            return await _unitOfWork.NovbeCedvelleri.UpdateAsync(schedule);
        }

        public async Task DeleteScheduleAsync(int id)
        {
            await _unitOfWork.NovbeCedvelleri.DeleteAsync(id);
        }

        public async Task<bool> DeactivateScheduleAsync(int id)
        {
            return await _unitOfWork.NovbeCedvelleri.DeactivateScheduleAsync(id);
        }

        public async Task<bool> ActivateScheduleAsync(int id)
        {
            return await _unitOfWork.NovbeCedvelleri.ActivateScheduleAsync(id);
        }

        #endregion

        #region Shift Management

        public async Task<IEnumerable<NovbeDetali>> GetAllShiftsAsync()
        {
            return await _unitOfWork.NovbeDetallari.GetAllAsync();
        }

        public async Task<NovbeDetali> GetShiftByIdAsync(int id)
        {
            return await _unitOfWork.NovbeDetallari.GetByIdAsync(id);
        }

        public async Task<IEnumerable<NovbeDetali>> GetShiftsByEmployeeAsync(int employeeId)
        {
            return await _unitOfWork.NovbeDetallari.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<IEnumerable<NovbeDetali>> GetShiftsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.NovbeDetallari.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<NovbeDetali>> GetTodayShiftsAsync()
        {
            return await _unitOfWork.NovbeDetallari.GetTodayShiftsAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetActiveShiftsAsync()
        {
            return await _unitOfWork.NovbeDetallari.GetActiveShiftsAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetPendingShiftApprovalsAsync()
        {
            return await _unitOfWork.NovbeDetallari.GetPendingApprovalsAsync();
        }

        public async Task<NovbeDetali> CreateShiftAsync(NovbeDetali shift)
        {
            // Check for conflicts before creating
            var hasConflict = await _unitOfWork.NovbeDetallari.HasConflictingShiftAsync(
                shift.IsciId, shift.NovbeTarixi, shift.BaslangicSaati, shift.BitisSaati);

            if (hasConflict)
            {
                throw new InvalidOperationException("Bu işçinin həmin tarixdə və saatda başqa növbəsi var!");
            }

            // Check if employee is on leave
            var isOnLeave = await IsEmployeeOnLeaveAsync(shift.IsciId, shift.NovbeTarixi);
            if (isOnLeave)
            {
                throw new InvalidOperationException("İşçi həmin tarixdə izindədir!");
            }

            return await _unitOfWork.NovbeDetallari.AddAsync(shift);
        }

        public async Task<NovbeDetali> UpdateShiftAsync(NovbeDetali shift)
        {
            // Check for conflicts when updating
            var hasConflict = await _unitOfWork.NovbeDetallari.HasConflictingShiftAsync(
                shift.IsciId, shift.NovbeTarixi, shift.BaslangicSaati, shift.BitisSaati, shift.Id);

            if (hasConflict)
            {
                throw new InvalidOperationException("Bu işçinin həmin tarixdə və saatda başqa növbəsi var!");
            }

            return await _unitOfWork.NovbeDetallari.UpdateAsync(shift);
        }

        public async Task DeleteShiftAsync(int id)
        {
            await _unitOfWork.NovbeDetallari.DeleteAsync(id);
        }

        public async Task<bool> ApproveShiftAsync(int shiftId, string approverName)
        {
            return await _unitOfWork.NovbeDetallari.ApproveShiftAsync(shiftId, approverName);
        }

        public async Task<bool> ApproveMultipleShiftsAsync(List<int> shiftIds, string approverName)
        {
            return await _unitOfWork.NovbeDetallari.ApproveMultipleShiftsAsync(shiftIds, approverName);
        }

        #endregion

        #region Leave Management

        public async Task<IEnumerable<IsciIzni>> GetAllLeavesAsync()
        {
            return await _unitOfWork.IsciIzinleri.GetAllAsync();
        }

        public async Task<IsciIzni> GetLeaveByIdAsync(int id)
        {
            return await _unitOfWork.IsciIzinleri.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IsciIzni>> GetLeavesByEmployeeAsync(int employeeId)
        {
            return await _unitOfWork.IsciIzinleri.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<IEnumerable<IsciIzni>> GetPendingLeavesAsync()
        {
            return await _unitOfWork.IsciIzinleri.GetPendingLeavesAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetActiveLeavesAsync()
        {
            return await _unitOfWork.IsciIzinleri.GetActiveLeavesAsync();
        }

        public async Task<IsciIzni> CreateLeaveRequestAsync(IsciIzni leave)
        {
            // Check for overlapping leaves
            var hasOverlap = await _unitOfWork.IsciIzinleri.HasOverlappingLeaveAsync(
                leave.IsciId, leave.BaslangicTarixi, leave.BitisTarixi);

            if (hasOverlap)
            {
                throw new InvalidOperationException("Bu tarix aralığında zaten təsdiqlənmiş izin var!");
            }

            return await _unitOfWork.IsciIzinleri.AddAsync(leave);
        }

        public async Task<IsciIzni> UpdateLeaveRequestAsync(IsciIzni leave)
        {
            // Check for overlapping leaves when updating
            var hasOverlap = await _unitOfWork.IsciIzinleri.HasOverlappingLeaveAsync(
                leave.IsciId, leave.BaslangicTarixi, leave.BitisTarixi, leave.Id);

            if (hasOverlap)
            {
                throw new InvalidOperationException("Bu tarix aralığında zaten təsdiqlənmiş izin var!");
            }

            return await _unitOfWork.IsciIzinleri.UpdateAsync(leave);
        }

        public async Task DeleteLeaveRequestAsync(int id)
        {
            await _unitOfWork.IsciIzinleri.DeleteAsync(id);
        }

        public async Task<bool> ApproveLeaveAsync(int leaveId, string approverName, string approvalNote = null)
        {
            return await _unitOfWork.IsciIzinleri.ApproveLeaveAsync(leaveId, approverName, approvalNote);
        }

        public async Task<bool> RejectLeaveAsync(int leaveId, string rejectorName, string rejectionReason)
        {
            return await _unitOfWork.IsciIzinleri.RejectLeaveAsync(leaveId, rejectorName, rejectionReason);
        }

        public async Task<bool> CancelLeaveAsync(int leaveId)
        {
            return await _unitOfWork.IsciIzinleri.CancelLeaveAsync(leaveId);
        }

        #endregion

        #region Reports and Analytics

        public async Task<decimal> GetEmployeeWorkingHoursAsync(int employeeId, DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.NovbeDetallari.GetTotalWorkingHoursAsync(employeeId, startDate, endDate);
        }

        public async Task<Dictionary<int, decimal>> GetWorkingHoursReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.NovbeDetallari.GetEmployeeWorkingHoursReportAsync(startDate, endDate);
        }

        public async Task<Dictionary<string, int>> GetLeaveStatisticsAsync(int employeeId, int year)
        {
            return await _unitOfWork.IsciIzinleri.GetLeaveStatisticsAsync(employeeId, year);
        }

        public async Task<int> GetTotalLeaveDaysAsync(int employeeId, string leaveType, int year)
        {
            return await _unitOfWork.IsciIzinleri.GetTotalLeaveDaysAsync(employeeId, leaveType, year);
        }

        #endregion

        #region Utility Methods

        public async Task<bool> IsEmployeeOnLeaveAsync(int employeeId, DateTime date)
        {
            var activeLeaves = await _unitOfWork.IsciIzinleri.GetActiveLeavesAsync();
            return activeLeaves.Any(l => l.IsciId == employeeId && 
                                       l.BaslangicTarixi.Date <= date.Date && 
                                       l.BitisTarixi.Date >= date.Date);
        }

        public async Task<bool> HasConflictingShiftAsync(int employeeId, DateTime shiftDate, TimeSpan startTime, TimeSpan endTime, int? excludeShiftId = null)
        {
            return await _unitOfWork.NovbeDetallari.HasConflictingShiftAsync(employeeId, shiftDate, startTime, endTime, excludeShiftId);
        }

        public async Task<bool> HasOverlappingLeaveAsync(int employeeId, DateTime startDate, DateTime endDate, int? excludeLeaveId = null)
        {
            return await _unitOfWork.IsciIzinleri.HasOverlappingLeaveAsync(employeeId, startDate, endDate, excludeLeaveId);
        }

        public async Task<IEnumerable<NovbeDetali>> SearchShiftsAsync(string searchTerm)
        {
            return await _unitOfWork.NovbeDetallari.GetAllAsync().ContinueWith(task => 
                task.Result.Where(s => s.Isci?.Ad.Contains(searchTerm) == true ||
                                     s.Isci?.Soyad.Contains(searchTerm) == true ||
                                     s.NovbeAdi?.Contains(searchTerm) == true));
        }

        public async Task<IEnumerable<IsciIzni>> SearchLeavesAsync(string searchTerm)
        {
            return await _unitOfWork.IsciIzinleri.SearchAsync(searchTerm);
        }

        public async Task<Dictionary<string, object>> GetDashboardDataAsync()
        {
            var today = DateTime.Today;
            var thisMonth = new DateTime(today.Year, today.Month, 1);
            var nextMonth = thisMonth.AddMonths(1);

            var todayShifts = await GetTodayShiftsAsync();
            var activeShifts = await GetActiveShiftsAsync();
            var pendingShifts = await GetPendingShiftApprovalsAsync();
            var pendingLeaves = await GetPendingLeavesAsync();
            var activeLeaves = await GetActiveLeavesAsync();

            return new Dictionary<string, object>
            {
                { "TodayShiftsCount", todayShifts.Count() },
                { "ActiveShiftsCount", activeShifts.Count() },
                { "PendingShiftsCount", pendingShifts.Count() },
                { "PendingLeavesCount", pendingLeaves.Count() },
                { "ActiveLeavesCount", activeLeaves.Count() },
                { "TodayShifts", todayShifts },
                { "ActiveShifts", activeShifts },
                { "PendingShifts", pendingShifts },
                { "PendingLeaves", pendingLeaves },
                { "ActiveLeaves", activeLeaves }
            };
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _unitOfWork?.Dispose();
                _disposed = true;
            }
        }
    }
}