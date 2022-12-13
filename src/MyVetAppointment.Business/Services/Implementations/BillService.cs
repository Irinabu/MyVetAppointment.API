using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPrescriptionDrugRepository _prescriptionDrugRepository;
        private readonly IDrugRepository _drugRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository billRepository, IAppointmentRepository appointmentRepository,
            IPrescriptionDrugRepository prescriptionDrugRepository, IDrugRepository drugRepository,
            IMapper mapper)
        {
            _billRepository = billRepository;
            _appointmentRepository = appointmentRepository;
            _prescriptionDrugRepository = prescriptionDrugRepository;
            _drugRepository = drugRepository;
            _mapper = mapper;
        }
        
        public async Task<List<BillResponse>> GetBillsAsync()
        {
            var bills = await _billRepository.GetAllLazyLoad(exp => true, x => x.PrescriptionDrugs);
            return _mapper.Map<List<Bill>, List<BillResponse>>(bills.ToList());
        }

        public async Task<BillResponse> AddBillAsync(BillRequest bill, Guid idAppointment)
        {
            var billEntity = _mapper.Map<BillRequest, Bill>(bill);
            var appointment = await _appointmentRepository.GetFirstLazyLoad(x => x.Id == idAppointment);
            appointment.Bill = billEntity;
            billEntity.Appointment = appointment;

            var prescriptionDrugs = new List<PrescriptionDrug>();
            foreach (var prescriptionDrug in bill.PrescriptionDrugs)
            {
                var prescriptionDrugEntity = _mapper.Map<PrescriptionDrugRequest, PrescriptionDrug>(prescriptionDrug);
                var drug = await _drugRepository.GetFirstAsync(x => x.Id == prescriptionDrug.DrugId);
                prescriptionDrugEntity.Drug = drug;
                prescriptionDrugs.Add(prescriptionDrugEntity);
            }

            billEntity.PrescriptionDrugs = prescriptionDrugs;
            billEntity.BillStatus = BillStatus.Pending;
            return _mapper.Map<Bill, BillResponse>(await _billRepository.AddAsync(billEntity));
        }

        public async Task DeleteBillAsync(Guid billId)
        {
            var bill = await _billRepository.GetFirstAsync(x => x.Id == billId);

            if (bill.PrescriptionDrugs != null)
            {
                foreach (var prescriptionDrug in bill.PrescriptionDrugs)
                {
                    await _prescriptionDrugRepository.DeleteAsync(prescriptionDrug);
                }
            }

            await _billRepository.DeleteAsync(bill);
        }

    }
}