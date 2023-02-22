using Authorization_RoleTest.Validation;
using Microsoft.AspNet.SignalR.Client.Http;

namespace SampleSchoolManagermentV1.Validation
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Stream GetStream()
        {
            throw new NotImplementedException();
        }
    }
}
