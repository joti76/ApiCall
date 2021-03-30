using ApiCall.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiCall
{
    public class ImgProcessor
    {
        public static async Task<DogModel> LoadDogImage()
        {
            string url = "";

            url = "https://random.dog/woof.json";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DogModel dog = await response.Content.ReadAsAsync<DogModel>();
                    Console.WriteLine($"DOG URL: {dog.Url}");
                    return dog;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
