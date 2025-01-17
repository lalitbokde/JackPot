﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using JackPot.Model;
using ModernHttpClient;

using WareHouseManagement.PCL.Common;

namespace JackPot.Helper
{
   public class HttpClientHelper
    {


        public async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }

                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            return default(T);
        }



        public async Task<ResultModel> Post<T>(T obj, string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var json = JsonConvert.SerializeObject(obj);
                var sendContent = new StringContent(json, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                  var Response=  JsonConvert.DeserializeObject<ResultModel>(content);
                    return Response;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }


        public async Task<ResultModel> PostData<T>(T obj, string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var json = JsonConvert.SerializeObject(obj);

                                var sendContent = new StringContent(json, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }
    }
}
