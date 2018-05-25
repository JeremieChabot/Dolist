using Dolist.Test.ServiceModel;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Dolist.Test.ServiceInterface
{
    public class MyServices : Service,
        IPost<PostClient>,
        IGet<GetClient>
    {
        public object Post(PostClient request)
        {
            using (var db = HostContext.Container.Resolve<IDbConnectionFactory>().Open())
            {
                return new ClientDAL(db.ToDbConnection()).InsertClient(new Client(request));
            }
        }
              
        public object Get(GetClient request)
        {
            using (var db = HostContext.Container.Resolve<IDbConnectionFactory>().Open())
            {
                return new ClientDAL(db.ToDbConnection()).SelectClientByID(request.ID);
            }
        }
    }
}