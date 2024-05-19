using AutoMapper;
using RaDumpsterAPI.Models;
using RaDumpsterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<DumpsterDTO, Dumpster>();
                config.CreateMap<Dumpster, DumpsterDTO>();

                config.CreateMap<DumpsterStatusDTO, DumpsterStatus>();
                config.CreateMap<DumpsterStatus, DumpsterStatusDTO>();

                config.CreateMap<DumpsterCategoryDTO, DumpsterCategory>();
                config.CreateMap<DumpsterCategory, DumpsterCategoryDTO>();

                config.CreateMap<DumpsterPriceDistanceDTO, DumpsterPriceDistance>();
                config.CreateMap<DumpsterPriceDistance, DumpsterPriceDistanceDTO>();

                config.CreateMap<SetupParameterDTO, SetupParameter>();
                config.CreateMap<SetupParameter, SetupParameterDTO>();

                config.CreateMap<ReserveDTO, Reserve>();
                config.CreateMap<Reserve, ReserveDTO>();
            });

            return mappingConfig;
        }

    }
}
