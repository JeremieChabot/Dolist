using Dolist.Test.ServiceModel;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;

namespace Dolist.Test.ServiceInterface
{
    internal sealed class ClientDAL
    {
        // The IDbConnection passed in from the IOC container on the service

        private IDbConnection dbConnection;

        // Store the database connection passed in

        public ClientDAL(IDbConnection dbConnection)

        {
            this.dbConnection = dbConnection;
        }

        public int InsertClient(Client client)
        {
            return (int)this.dbConnection.Insert(client, selectIdentity: true);
        }

        
        public Client SelectClientByID(int clientID)
        {
            return this.dbConnection.SingleById<Client>(clientID);
        }

        public IList<Client> SelectClientList()
        {
            return this.dbConnection.Select<Client>();
        }
        
    }
}
