using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.TenantManagement;

namespace Pillio.Data
{
    public class PillioDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CareHome, Guid> _careHomeRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<Tenant, Guid> _tenantRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IRepository<Pharmacy, Guid> _pharmacyRepository;
        private readonly IRepository<DoctorOffice, Guid> _doctorOfficeRepository;
        public PillioDataSeederContributor(IRepository<CareHome, Guid> careHomeRepository, IGuidGenerator guidGenerator, IRepository<Tenant, Guid> tenantRepository, ITenantManager tenantManager, IRepository<Pharmacy, Guid> pharmacyRepository, IRepository<DoctorOffice, Guid> doctorOfficeRepository)
        {
            _careHomeRepository = careHomeRepository;
            _guidGenerator = guidGenerator;
            _tenantRepository = tenantRepository;
            _tenantManager = tenantManager;
            _pharmacyRepository = pharmacyRepository;
            _doctorOfficeRepository = doctorOfficeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _careHomeRepository.GetCountAsync() <= 0)
            {
                var careHome = await _tenantManager.CreateAsync("Pflegeheim Berlin");
                var careHome2 = await _tenantManager.CreateAsync("Demo Pflegeheim");
                var doctorOffice = await _tenantManager.CreateAsync("Marios Grolich");
                var doctorOffice2 = await _tenantManager.CreateAsync("Demo Doctor Office");
                var pharmacy = await _tenantManager.CreateAsync("Lukas Feyer");
                var pharmacy2 = await _tenantManager.CreateAsync("Demo Pharmacy");


                await _pharmacyRepository.InsertAsync(new Pharmacy(_guidGenerator.Create())
                {
                    Name = "Lukas Feyer",
                    PharmacyTenantId = pharmacy.Id
                });

                await _pharmacyRepository.InsertAsync(new Pharmacy(_guidGenerator.Create())
                {
                    Name = "Demo Pharmacy",
                    PharmacyTenantId = pharmacy2.Id
                });

                await _doctorOfficeRepository.InsertAsync(new DoctorOffice(_guidGenerator.Create())
                {
                    Name = "Marios Grolich",

                    DoctorTenantId = doctorOffice.Id
                });

                await _doctorOfficeRepository.InsertAsync(new DoctorOffice(_guidGenerator.Create())
                {
                    Name = "Demo Doctor Office",

                    DoctorTenantId = doctorOffice2.Id
                });

                await _careHomeRepository.InsertAsync(new CareHome(_guidGenerator.Create())
                {
                    Name = "Pflegeheim Berlin",
                    Stations = new List<Station>
                    {
                        new Station (_guidGenerator.Create())
                        {
                            Name = "Mitte 1",
                        },
                        new Station(_guidGenerator.Create())
                        {
                            Name = "Mitte 2",
                        },
                        new Station(_guidGenerator.Create())
                        {
                            Name = "Mitte 3",
                        }
                    },
                    CareHomeTenantId = careHome.Id
                });
                await _careHomeRepository.InsertAsync(new CareHome(_guidGenerator.Create())
                {
                    Name = "Demo Pflegeheim",
                    Stations = new List<Station>
                    {
                        new Station(_guidGenerator.Create())
                        {
                            Name = "Mitte 1",
                        },
                        new Station(_guidGenerator.Create())
                        {
                            Name = "Mitte 2",
                        },
                        new Station(_guidGenerator.Create())
                        {
                            Name = "Mitte 3",
                        }
                    },
                    CareHomeTenantId = careHome2.Id
                });

            }
        }
    }
}
