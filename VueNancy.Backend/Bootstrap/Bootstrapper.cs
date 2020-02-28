using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace VueNancy.Backend.Bootstrap
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            AllowAccessToConsumingSite(pipelines);
        }

        private static void AllowAccessToConsumingSite(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
            {
                x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET");
                x.Response.Headers.Add("Access-Control-Allow-Headers", "Content-type");
            });
        }
    }
}