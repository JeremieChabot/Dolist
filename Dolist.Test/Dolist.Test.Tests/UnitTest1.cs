using Dolist.Test.ServiceInterface;
using Dolist.Test.ServiceModel;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;

namespace Dolist.Test.Tests
{
    public class UnitTests
    {
        private ServiceStackHost appHost;

        private JsonServiceClient client;

        private const string host = "http://localhost:8108/";

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            appHost = new AppHost()
            .Init()
            .Start(host);

            client = new JsonServiceClient(host);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            client.Dispose();
            appHost.Dispose();
        }

        [Test]
        public void CRUD()
        {
            //À noter que je n'ai encore jamais développé sérieusement d'application en utilisant Visual Studio
            //Ce problème est donc assez peu représentatif de mon niveau en C#, ayant été majoritairement bloqué par la systémique de cette application.
            //Explications:
            //1) J'ai réussi à installer correctement ServiceStack et ormlite (à partir du PMC que je ne connaissais pas)
            //2) Je ne peux pas suivre le tutoriel ServiceStack correctement puisqu'une erreur m'empêche de créer un nouveau projet servicestack complet, le premier projet refusant de se créer.
            //(après 10 - 15 minutes de recherche sur l'erreur j'ai préféré abadonner et essayer de comprendre moi même l'arborescence).
            //3) De ce que j'ai compris:
            // -La classe "Client" de .ServiceModel comporte toutes les informations d'un client. Son constructeur permet de renseigner le nom et prénom, l'ID et la date de création devant être déterminée par le code.
            // -La classe "GetClient" de .ServiceModel sert à récupérer une ID (pour la comparer avec une ID client plus tard dans la méthode CRUD je suppose)
            //4) Je n'arrive pas à comprendre comment modifier l'interface client, je ne vois aucun fichier html/js et ne sait pas où en créer. La documentation ( http://docs.servicestack.net/csharp-client#jsonhttpclient ) ne m'aide pas à cet égard
            //5) De fait, je ne peux pas tester le fait de rentrer un nom/prénom et comprendre comment les infos s'agencent dans le code.
            //6) J'ai tenté de partiellement répondre au problème en implémentant les algorithmes de manière artificielle ci dessous. Je ne suis pas sûr de ce que représentent les étapes ci dessous

            // !! Je suis conscient que les classes que j'instancie ici sont vides, mais je ne sais pas comment récupérer les informations rentrées à partir de l'application elle même !! 
            // Tester le post
                Client NvClient = new Client();
                PostClient PostClient = new PostClient();
                if (NvClient.FirstName == PostClient.FirstName && NvClient.LastName == PostClient.LastName)
                {
                    //validation
                }
                else
                {
                    //erreur
                }

            // Vérfier l'identifiant retourné
                GetClient getclient = new GetClient(NvClient.ID);
                if(NvClient.ID == getclient.ID)
                {
                //validation
                }
                else
                {
                   //erreur
                }

            // Tester le put

            // Tester le get

            // Vérifier que le put a bien été appliqué

            // Test le delete
        }
    }
}
