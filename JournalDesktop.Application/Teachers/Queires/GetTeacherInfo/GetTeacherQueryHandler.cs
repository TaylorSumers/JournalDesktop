using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JournalDesktop.Domain;

namespace JournalDesktop.Application.Teachers.Queires.GetTeacherInfo
{
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, Teacher>
    {
        //private readonly IApiRequestExecutor _apiRequestExecutor

        public GetTeacherQueryHandler()
        {
            // _apiRequestExecutor = apiRequestExecutor
        }

        public async Task<Teacher> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7043/api/");

            var httpResponseMessage = await httpClient.GetAsync($"Teachers/Get?login={request.Login}&password={request.Password}", cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception();

            var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
            var teacher = JsonConvert.DeserializeObject<Teacher>(content);

            return teacher;
        }
    }
}
