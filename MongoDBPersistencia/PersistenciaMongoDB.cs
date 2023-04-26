using ContratoPersistencia;
using MongoDB.Driver;

namespace MongoDBPersistencia
{
    public class PersistenciaMongoDB : APersistencia
    {
        private string stringConexao;
        private readonly IMongoCollection<IEntidade> collection;

        public PersistenciaMongoDB(string _conexao, string nomeBanco, string nomeColecao)
        {
            stringConexao = _conexao;
            var client = new MongoClient(_conexao);
            var database = client.GetDatabase(nomeBanco);
            collection = database.GetCollection<IEntidade>(nomeColecao);
        }

        public override void Apagar(IEntidade entidade)
        {
            var filter = Builders<IEntidade>.Filter.Eq(e => e.Id, entidade.Id);
            collection.DeleteOne(filter);
        }

        public override void Atualizar(IEntidade entidade)
        {
            var filter = Builders<IEntidade>.Filter.Eq(e => e.Id, entidade.Id);
            var update = Builders<IEntidade>.Update.Set(e => e, entidade);
            collection.UpdateOne(filter, update);
        }

        public override List<IEntidade> Buscar(Type tipoEntidade)
        {
            var entities = collection.Find(Builders<IEntidade>.Filter.Empty).ToList();
            return entities.Where(e => e.GetType() == tipoEntidade).ToList();
        }

        public override void Incluir(IEntidade entidade)
        {
            collection.InsertOne(entidade);

        }
    }
}
/*
using MongoDB.Driver;
using MongoDB.Bson;
const string connectionUri = "mongodb+srv://raissa:<password>@cluster0.lxkzp.mongodb.net/?retryWrites=true&w=majority";
var settings = MongoClientSettings.FromConnectionString(connectionUri);
// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
// Create a new client and connect to the server
var client = new MongoClient(settings);
// Send a ping to confirm a successful connection
try {
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
} catch (Exception ex) {
    Console.WriteLine(ex);
}*/