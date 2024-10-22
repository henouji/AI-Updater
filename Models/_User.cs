using AI_Updater.SqlModels;

namespace AI_Updater.Models
{
    public class _User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User GetSqlModel()
        {
            return new User()
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}
