using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplicationTest.Models
{
    public class TopicManager
    {
        public List<T> GetTopicById<T>(List<T> lst, string url, string id)
        {

            var resultlist = lst;
            var client = new HttpClient();
            var getDataTask = client.GetAsync(url + id)
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<T>>();
                        readResult.Wait();

                        resultlist = readResult.Result;
                        lst = resultlist;

                    }
                });
            getDataTask.Wait();
            return lst;
        }

        public List<T> GetTopicByIdInt<T>(List<T> lst, string url, int id)
        {

            var resultlist = lst;
            var client = new HttpClient();
            var getDataTask = client.GetAsync(url + id)
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<T>>();
                        readResult.Wait();

                        resultlist = readResult.Result;
                        lst = resultlist;

                    }
                });
            getDataTask.Wait();
            return lst;
        }
    }
}