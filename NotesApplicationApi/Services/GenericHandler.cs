using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace NotesApplicationApi.Services
{
    public class GenericHandler<T>
    {
        /// <summary>
        /// This is the objevt i get back from ReturnResultsFromApi, T becames Rootobject
        /// </summary>
        public T GetserializeObject;

        /// <summary>
        /// I dit it generic but is not necessary,
        /// This is here i seralizied object that i want seriliazied, in this case T becomes Rootobject
        /// Like this i called this method GenericHandler<RootObject> _genericLogic = new GenericHandler<RootObject>();
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<T> ReturnResultsFromApi(string uri)
        {
            string json = string.Empty;
            try
            {
                json = LogicHandler.GetJson(uri);
                var data = new JavaScriptSerializer().Deserialize<T>(json);
                return await Task.FromResult(data);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}