using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SalesManagementApp.data.repositories;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
 
namespace SalesManagementApp.Data.Repositories
{

    
    public class UserRepository: IUserRepository
    {

        private readonly HttpClient _httpClient;
        private List <User> _users;
        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _users = new List<User>
            {
                new User { Id = 1, FullName = "Nguyễn Văn A", Email = "a@gmail.com", Role = "Admin" },
                new User { Id = 2, FullName = "Trần Thị B", Email = "b@gmail.com", Role = "User" },
                new User { Id = 3, FullName = "Lê Văn C1", Email = "c@gmail.com", Role = "Manager" }
            };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await GetUsersAsync_m();
            //var response = await _httpClient.GetStringAsync("https://api.example.com/users");
            //return JsonSerializer.Deserialize<List<User>>(response);
            //var json = await response.Content.ReadAsStringAsync();
            //var user = JsonSerializer.Deserialize<User>(json);
        }
        public async Task<List<User>> GetUsersAsync_m()
        {
            await Task.Delay(1000); // Giả lập thời gian tải dữ liệu

            return _users;
        }
        public async Task AddUserAsync(User user)
        {
            await Task.Delay(1000);
            _users.Add(user);
            //var json = JsonSerializer.Serialize(user);
            //var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //await _httpClient.PostAsync("https://api.example.com/users", content);
        }

        public async Task UpdateUserAsync(User updatedUser)
        {
            await Task.Delay(300); // giả lập gọi API

            var index = _users.FindIndex(u => u.Id == updatedUser.Id);
            if (index >= 0)
            {
                _users[index] = updatedUser;
            }
            //var json = JsonSerializer.Serialize(user);
            //var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //await _httpClient.PutAsync($"https://api.example.com/users/{user.Id}", content);
        }

        public async Task DeleteUserAsync(int id)
        {
            await Task.Delay(300); // mô phỏng thời gian gọi API

            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            //await _httpClient.DeleteAsync($"https://api.example.com/users/{id}");
        }
    }
    
}
