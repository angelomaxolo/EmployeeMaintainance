using Employeemaintainance.Models.DTOs.Employee;
using Employeemaintainance.Models.DTOs.Person;
using EmployeeMaintainance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Web.Controllers
{
    public class AdminController: Controller
    {
        //private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> Employee(int id)
        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var request = new  HttpRequestMessage(HttpMethod.Get, "api/employee/" + id);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<CreateEmployeeDTO>(content);

            return View(employee);
        }
        
        public async Task<IActionResult> Employees()

        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "api/employee");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<CreateEmployeeDTO>>(content);

            return View(employees);
        }

        public async Task<IActionResult> Create(EmployeeFormViewModel viewModel)
        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                if (!ModelState.IsValid)
                {
                    return View("EmployeeForm");
                }

                var employee = new CreateEmployeeDTO
                {
                    EmployeeNumber = viewModel.EmployeeNumber,
                    EmployedDate = viewModel.EmployedDate,
                    TerminatedDate = viewModel.TerminatedDate,
                    Person = new PersonDTO
                    {
                        LastName = viewModel.LastName,
                        FirstName = viewModel.FirstName,
                        DateOfBirth = viewModel.BirthDate
                    }
                
                };

                var serializedEmployeeToCreate = JsonConvert.SerializeObject(employee);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/employee");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                request.Content = new StringContent(serializedEmployeeToCreate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            //var createdEmployee = JsonConvert.DeserializeObject<CreateEmployeeDTO>(content);

            return RedirectToAction("Employees", "Admin");
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "api/employee/" + id);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<CreateEmployeeDTO>(content);

            
            if (employee == null)
            {
                return RedirectToAction("Employee", "Admin");
            }

            var viewModel =  new EmployeeFormViewModel
            {
                Id = employee.Id,
                EmployeeNumber = employee.EmployeeNumber,
                EmployedDate = employee.EmployedDate,
                TerminatedDate = employee.TerminatedDate
            };

            return View("EmployeeEditForm", viewModel);
        }

        public async Task<IActionResult> Update(int id, EmployeeFormViewModel viewModel)
        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var employee = new UpdateEmployeeDTO
                {
                    Id = viewModel.Id,
                    EmployeeNumber = viewModel.EmployeeNumber,
                    EmployedDate = viewModel.EmployedDate,
                    TerminatedDate = viewModel.TerminatedDate
                };

                var serializedEmployeeToUpdate = JsonConvert.SerializeObject(employee);

                var request = new HttpRequestMessage(HttpMethod.Put, "api/employee/" + id);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedEmployeeToUpdate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updateEmployee = JsonConvert.DeserializeObject<UpdateEmployeeDTO>(content);

            return RedirectToAction("Employee", "Admin", new{id = viewModel.Id});
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response;
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, "api/employee/" + id);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await httpClient.SendAsync(request);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return RedirectToAction("Employees","Admin");
        }
    }
}
