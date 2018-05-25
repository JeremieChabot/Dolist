using ServiceStack;

namespace Dolist.Test.ServiceModel
{
    [Route("/client/{id}", Verbs = "GET")]
    public sealed class GetClient: IReturn<Client>
    {
        public int ID { get; set; }

        public GetClient(int requestID)
        {
            this.ID = requestID;
        }
    }
}
