using System.Runtime.Serialization;

namespace PharmaWarehouse.Api.Dtos
{
    [DataContract]
    public class ErrorDto
    {
        public ErrorDto()
        {
        }

        public ErrorDto(string message)
        {
            this.Message = message;
        }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}
