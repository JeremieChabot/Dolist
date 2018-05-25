using ServiceStack;

namespace Dolist.Test.ServiceModel
{
    [Route("/client", Verbs = "POST")]
    public sealed class PostClient: IReturn<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
