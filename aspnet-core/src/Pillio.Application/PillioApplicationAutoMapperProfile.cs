using Pillio.Organizations;
using Pillio.Organizations.Dtos;
using Pillio.Organizations.Pharmacies.Dtos;
using AutoMapper;

namespace Pillio;

public class PillioApplicationAutoMapperProfile : Profile
{
    public PillioApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CareHome, CareHomeDto>();
        CreateMap<CreateOrEditCareHomeDto, CareHome>();
        CreateMap<DoctorOffice, DoctorOfficeDto>();
        CreateMap<CreateOrEditDoctorOfficeDto, DoctorOffice>();
        CreateMap<Pharmacy,PharmacyDto>();
        CreateMap<CreateOrEditPharmacyDto, Pharmacy>(); 
    }
}
