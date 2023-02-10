namespace SistemaGestionProyectoFinal.Models
{
    public class Venta
    {
        private long id;
        private string comentarios;
        private long idUser;

        public long Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public long IdUser { get => idUser; set => idUser = value; }
    }
}
