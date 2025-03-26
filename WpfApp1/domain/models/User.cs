using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Text.Json.Serialization;

namespace SalesManagementApp.domain.models
{
    public class User
    {
        private string v1;
        private bool v2;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("google_id")]
        public string? GoogleId { get; set; }

        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("ugroup_id")]
        public int? UgroupId { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } = "customer";

        [JsonPropertyName("budget")]
        public long Budget { get; set; } = 0;

        [JsonPropertyName("totalpoint")]
        public long TotalPoint { get; set; } = 0;

        [JsonPropertyName("totalrevenue")]
        public long TotalRevenue { get; set; } = 0;

        [JsonPropertyName("totalinvoice")]
        public long TotalInvoice { get; set; } = 0;

        [JsonPropertyName("taxcode")]
        public string? TaxCode { get; set; }

        [JsonPropertyName("taxname")]
        public string? TaxName { get; set; }

        [JsonPropertyName("taxaddress")]
        public string? TaxAddress { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "active";

        [JsonPropertyName("remember_token")]
        public string? RememberToken { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Không lưu trong DB, chỉ dùng để chọn UI
        [JsonIgnore]
        public bool IsSelected { get; set; } = false;

        // ✅ Constructor mặc định
        public User() { }

        // ✅ Constructor rút gọn (đủ dùng khi nhập tay)
        public User(string fullName, string email, string gender, string phone, string password,string address,string role,string photo = "", string description = ""
             )
        {
            FullName = fullName;
            Email = email;
            Gender = gender;
            Phone = phone;
            Password = password;
            Role = role;
            Photo = photo;
            Description = description;
            Address = address;
        }
        

        // ✅ Constructor đầy đủ tất cả trường
        public User(
            int id,
            string? code,
            string fullName,
            string? username,
            string email,
            string gender,
            DateTime birthday,
            DateTime? emailVerifiedAt,
            string password,
            string? photo,
            string phone,
            string? googleId,
            string? facebookId,
            string? address,
            string? description,
            int? ugroupId,
            string role,
            long budget,
            long totalPoint,
            long totalRevenue,
            long totalInvoice,
            string? taxCode,
            string? taxName,
            string? taxAddress,
            string status,
            string? rememberToken,
            DateTime createdAt,
            DateTime updatedAt
        )
        {
            Id = id;
            Code = code;
            FullName = fullName;
            Username = username;
            Email = email;
            Gender = gender;
            Birthday = birthday;
            EmailVerifiedAt = emailVerifiedAt;
            Password = password;
            Photo = photo;
            Phone = phone;
            GoogleId = googleId;
            FacebookId = facebookId;
            Address = address;
            Description = description;
            UgroupId = ugroupId;
            Role = role;
            Budget = budget;
            TotalPoint = totalPoint;
            TotalRevenue = totalRevenue;
            TotalInvoice = totalInvoice;
            TaxCode = taxCode;
            TaxName = taxName;
            TaxAddress = taxAddress;
            Status = status;
            RememberToken = rememberToken;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public User(string fullName, string email, string v1, bool v2)
        {
            FullName = fullName;
            Email = email;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}

