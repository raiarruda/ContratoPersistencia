namespace app.Models;
public class Cliente : IEntidade
    {
        public Cliente()
        {
            int timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            this.Id = timestamp;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
