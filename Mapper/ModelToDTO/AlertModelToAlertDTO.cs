using UmbracoDemoSite.DTO;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Mapper.ModelToDTO
{
    public class AlertModelToAlertDTO : Mapper
    {
        public override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) { return default(TOutput); }

            var model = source as Alert;

            var _Infomration = model.AlertContent.ToString();
            var _AlertType = model.AlertType.ToString();

            return new AlertDTO
            {
                Infomration = model.AlertContent.ToString(),
                AlertType = model.AlertType.ToString()
            } as TOutput;
           
        }
    }
}