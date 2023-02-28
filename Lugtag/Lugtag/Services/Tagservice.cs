using Lugtag.Models;
using MongoDB.Driver;

namespace Lugtag.Services
{
    public class Tagservice
    {
        MongoClient client;
        IMongoDatabase database;
        public Tagservice()
        {
            client = new MongoClient(Consts.MONGODBCONNECTIONSTRING);
            database = client.GetDatabase("LugTag");
     
        }

        public async Task<TagModel> GetTagByLinkIdentifier(string linkIdentifier)
        {
            var filter = Builders<TagModel>.Filter.Eq(s => s.LinkIdentifier, linkIdentifier);
            var result = await database.GetCollection<TagModel>("Tags").FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task AddTag(TagModel tag)
        {
            await database.GetCollection<TagModel>("Tags").InsertOneAsync(tag);
        }

        public async Task UpdateTag(TagModel tagToUpdate)
        {
            var filter = Builders<TagModel>.Filter.Eq(s => s.Id, tagToUpdate.Id);
            await database.GetCollection<TagModel>("Tags").ReplaceOneAsync(filter, tagToUpdate);
        }

        public async Task DeleteTag(TagModel tagToDelete)
        {
            var filter = Builders<TagModel>.Filter.Eq(s => s.Id, tagToDelete.Id);
            await database.GetCollection<TagModel>("Tags").DeleteOneAsync(filter);
        }


        public async Task<List<TagModel>> GetAllTags()
        {
            var result = await database.GetCollection<TagModel>("Tags").FindAsync(_ => true);
            return result.ToList();
        }
    }
}
