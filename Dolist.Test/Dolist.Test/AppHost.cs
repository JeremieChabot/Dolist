using Funq;
using ServiceStack;
using Dolist.Test.ServiceInterface;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Dolist.Test.ServiceModel;

namespace Dolist.Test
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("Dolist.Test", typeof(MyServices).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            // Add our IDbConnectionFactory to the container, this will
            // allow all of our services to share a single connection factory
            container.Register<IDbConnectionFactory>(c =>
               new OrmLiteConnectionFactory(@"Data Source=.\mydb.db; Version=3;", SqliteDialect.Provider));

            // Below we refer to the connection factory that we just registered
            // with the container and use it to create our table(s).
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                // We’re just creating a single table, but you could add
                // as many as you need.  Also note the “overwrite: false” parameter,
                // this will only create the table if it doesn’t already exist.
                db.CreateTable<Client>(overwrite: false);
            }
        }
    }
}
