using c_sharp_API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;



internal class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            List<Country> countryList = await CallAPI();

            if (countryList != null)
            {
                Console.WriteLine("List of countries:");
                 foreach (Country country in countryList)
                {
                   Console.WriteLine(country.ToString());
                }
            }
            else
            {
                Console.WriteLine("Failed to fetch data from the API.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


     public  async static Task<List<Country>> CallAPI()
    {
        try { 
        string API = "https://restcountries.com/v3.1/all?fields=name,capital,area";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage ResponseMessage = await httpClient.GetAsync(API);
                List<Country> CountryList = new List<Country>();

                if (ResponseMessage.IsSuccessStatusCode)
                {
                    string stringRes = await ResponseMessage.Content.ReadAsStringAsync();
                    /*
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
                    */

                    List<Country> a = JsonConvert.DeserializeObject<List<Country>>(stringRes);//Newtonsoft.Json

                    return a;
                }
                else
                {
                    Console.WriteLine("Failed to get data from the API.");
                }

            }

            return null;
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

        

    }
    /*
    public async void callWeatherAPI()
    {
        try
        {
            string baseurl=""

        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    */
   

}
    
