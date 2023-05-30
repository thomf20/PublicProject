using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PublicProject.API
{
    public  class PasswordGeneratorAPI
    {
       
        public static async Task<List<Models.Password>> GetRandomPassword()
        {
            List<Models.Password> RandomGeneratedPassword = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://snackismetapi.azurewebsites.net/api/password");

                HttpResponseMessage response = await client.GetAsync("/api/Password");
                if (response.IsSuccessStatusCode)
                {
                    string responsestring = await response.Content.ReadAsStringAsync();
                    RandomGeneratedPassword = JsonSerializer.Deserialize<List<Models.Password>>(responsestring);
                }
            }
            return RandomGeneratedPassword;
        }

   
    }
}
