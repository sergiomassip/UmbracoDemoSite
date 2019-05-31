using System;
using UmbracoDemoSite.Mapper.ModelToDTO;

namespace UmbracoDemoSite.Mapper
{
    public static class SwitchMapperModeltoDTO
    {
        public static Mapper GetMapperFor(ModelToDTOEnum name, params object[] interfaces)
        {
            switch (name)
            {
                case ModelToDTOEnum.AlertModeltoAlertDTO:
                    return new AlertModelToAlertDTO();
                default:
                    throw new NotImplementedException(string.Format("Missing mapper for {0} in  UmbracoDemoSite.Mapper.SwitchMapperModeltoDTO", name.ToString()));
            }
        }
    }
}