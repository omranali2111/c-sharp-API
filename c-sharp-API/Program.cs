using c_sharp_API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;



internal class Program
{
    static async Task Main(string[] args)
    {
        List<Country> response = await CallAPI();
        foreach (Country country in response)
        {
            Console.WriteLine(country);
           
        }
    }
     public  async static Task<List<Country>> CallAPI()
    {
        string API = "https://restcountries.com/v3.1/all?fields=name,capital,area";
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage ResponseMessage = await httpClient.GetAsync(API);
        List<Country> CountryList = new List<Country>();

        if (ResponseMessage.IsSuccessStatusCode)
        {
            string stringRes=await ResponseMessage.Content.ReadAsStringAsync();
            JsonDocument document=JsonDocument.Parse(stringRes);
            JsonElement root= document.RootElement;
            if(root.ValueKind == JsonValueKind.Array)
            {
                var enumerator = root.EnumerateArray;
                foreach (JsonElement country in root.EnumerateArray())
                {
                    String capital="";
                    if(country.GetProperty("capital").GetArrayLength() > 0)
                    {
                        capital = country.GetProperty("capital")[0].GetString();
                    }

                    double area=country.GetProperty("area").GetDouble();
                    string officialName=country.GetProperty("name").GetProperty("official").GetString();

                    CountryList.Add(new Country(officialName, capital, area));

                }
            }


            

           
        }
        return CountryList;


     }
   

}
    
